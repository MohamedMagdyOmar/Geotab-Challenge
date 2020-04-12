using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public class Utilities
    {
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
            if(firstName != null && lastName != null)
            {
                // validate if it comes at the end of the sentence, or at the beginning of a sentence, or did not come at all
                int index = joke.ToLower().IndexOf(nameToBeReplaced.ToLower());
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + nameToBeReplaced.Length, joke.Length - (index + nameToBeReplaced.Length));
                joke = firstPart + " " + firstName + " " + lastName + secondPart;
            }

            return joke;
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
