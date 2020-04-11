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

        public List<string> GetJokeCategories()
        {
            return _controller.GetAllJokesCategories();
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

        public List<string> GetListOfJokesByCategoryAndDefaultName(int numberOfJokes, string jokeCategory)
        {
            List<string> listOfJokes = new List<string>();
            for (int i = 0; i < numberOfJokes; i++)
            {
                listOfJokes.Add(_controller.GetJokesByCategory(jokeCategory));
            }
            return listOfJokes;
        }

        public List<string> GetListOfJokesByCategoryAndSpecificName(int numberOfJokes, string jokeCategory, string firstName, string lastName)
        {
            List<string> listOfJokes = new List<string>();
            for (int i = 0; i < numberOfJokes; i++)
            {
                string joke = _controller.GetJokesByCategory(jokeCategory);
                joke = _utilities.ReplaceNameInJoke(firstName, lastName, joke);
                listOfJokes.Add(joke);
            }
            return listOfJokes;
        }
    }
}
