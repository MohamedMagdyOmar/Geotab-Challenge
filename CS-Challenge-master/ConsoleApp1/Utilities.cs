using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JokeGenerator
{
    public class Utilities
    {
        public bool isNameReplaced = false;
        private bool isJokeClean = false;
        public string AppendJokeCategory(string url, string jokeCategory)
        {
            if (jokeCategory != null)
            {
                if (url.Contains('?'))
                    url += "&";
                else url += "?";
                url += "category=";
                url += jokeCategory;
            }
            return url;
        }

        public string ReplaceNameInJoke(string firstName, string lastName, string joke, string nameToBeReplaced = "Chuck Norris")
        {
            string jokeWithputWhiteSpace = string.Concat(joke.Where(c => !char.IsWhiteSpace(c)));
            string nameToReplacedWithoutWhiteSpace = string.Concat(nameToBeReplaced.Where(c => !char.IsWhiteSpace(c)));

            if(firstName == null || lastName == null)
            {
                return joke;
            }

            else if (firstName != null && lastName != null && joke.ToLower().Contains(nameToBeReplaced.ToLower()))
            {
                isJokeClean = true;
            }
            else if (jokeWithputWhiteSpace.ToLower().Contains(nameToReplacedWithoutWhiteSpace.ToLower()))
            {
                joke = AdjustJokeSpaces(joke, nameToBeReplaced);
                isJokeClean = true;
            }

            if(isJokeClean)
            {
                var occurrences = Regex.Matches(joke.ToLower(), nameToBeReplaced.ToLower()).Count;

                for (int i = 0; i < occurrences; i++)
                {
                    int index = joke.ToLower().Trim().IndexOf(nameToBeReplaced.ToLower().Trim());
                    string firstPart = joke.Substring(0, index).Trim();
                    string secondPart = joke.Substring(0 + index + nameToBeReplaced.Length, joke.Length - (index + nameToBeReplaced.Length));
                    joke = firstPart + " " + firstName + " " + lastName + secondPart;
                    joke = joke.Trim();
                }

                isNameReplaced = true;
            }
            return joke;
        }

        public string AdjustJokeSpaces(string joke, string nameToBeReplaced)
        {
            var firstNameToBeReplaced = String.Concat(nameToBeReplaced.TakeWhile(c => c != ' '));
            var lastNameToBeReplaced = String.Concat(nameToBeReplaced.TakeLast(firstNameToBeReplaced.Length + 1));

            joke = joke.Insert(joke.IndexOf(firstNameToBeReplaced) + firstNameToBeReplaced.Length, " ");
            joke = joke.Insert(joke.IndexOf(firstNameToBeReplaced) - 1, " ");
            joke = joke.Insert(joke.IndexOf(lastNameToBeReplaced) + lastNameToBeReplaced.Length, " ");
            joke = joke.Insert(joke.IndexOf(firstNameToBeReplaced) - 1, " ");

            return Regex.Replace(joke, @"\s+", " ");
        }

        public void PrintResults(List<string> results)
        {
            for(int i = 0; i < results.Count; i++)
            {
                Console.WriteLine((i + 1) + "- " + results[i]);
            }
        }
    }
}
