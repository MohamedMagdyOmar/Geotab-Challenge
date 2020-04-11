using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public class Services
    {
        private JokesController _controller;
        private Utilities _utilities;
        public Services()
        {
            // we can use dependency injection
            _controller = new JokesController();
            _utilities = new Utilities();
        }

        public string GetRandomJokesWithDefaultName()
        {
            return _controller.GetRandomJokes();
        }

        public string GetRandomJokesWithSpecificName(string firstName, string lastName)
        {
            string joke = _controller.GetRandomJokes();
            return _utilities.ReplaceNameInJoke(firstName, lastName, joke);
        }

        public List<string> GetListOfRandomJokesWithDefaultName(int numberOfJokes)
        {
            List<string> listOfRandomJokes = new List<string>();
            for(int i = 0; i < numberOfJokes; i++)
            {
                listOfRandomJokes.Add(_controller.GetRandomJokes());
            }
            return listOfRandomJokes;
        }

        public List<string> GetListOfRandomJokesWithSpecificName(int numberOfJokes, string firstName, string lastName)
        {
            List<string> listOfRandomJokes = new List<string>();
            for (int i = 0; i < numberOfJokes; i++)
            {
                string joke = _controller.GetRandomJokes();
                joke = _utilities.ReplaceNameInJoke(firstName, lastName, joke);
                listOfRandomJokes.Add(joke);
            }
            return listOfRandomJokes;
        }

        public string GetJokeByCategoryByDefaultName(string jokeCategory)
        {
            return _controller.GetJokesByCategory(jokeCategory);
        }

        public string GetJokeByCategoryBySpecificName(string category, string firstName, string lastName)
        {
            string joke = _controller.GetJokesByCategory(category);
            return _utilities.ReplaceNameInJoke(firstName, lastName, joke);
        }

        public List<string> GetListOfJokesByCategoryAndDefaultName(int numberOfJokes, string jokeCategory)
        {
            List<string> listOfJokes = new List<string>();
            for (int i = 0; i < numberOfJokes; i++)
            {
                listOfJokes.Add(_controller.GetJokesByCategory(jokeCategory));
            }
            return listOfJokes;
        }

        public List<string> GetListOfJokesByCategoryAndSpecificName(string category, string firstName, string lastName, int numberOfJokes)
        {
            List<string> listOfJokes = new List<string>();
            for (int i = 0; i < numberOfJokes; i++)
            {
                string joke = _controller.GetJokesByCategory(category);
                joke = _utilities.ReplaceNameInJoke(firstName, lastName, joke);
                listOfJokes.Add(joke);
            }
            return listOfJokes;
        }
    }
}
