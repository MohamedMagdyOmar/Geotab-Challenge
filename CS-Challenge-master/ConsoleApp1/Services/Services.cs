using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public class Services
    {
        private readonly JokesController _controller;
        private readonly Utilities _utilities;
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

        public List<string> GetListOfRandomJokes(int numberOfJokes, string firstName, string lastName)
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

        public List<string> GetListOfJokesByCategory(int numberOfJokes, string jokeCategory, string firstName, string lastName)
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

        public dynamic GetNames()
        {
            return _controller.GetNames();
        }
    }
}
