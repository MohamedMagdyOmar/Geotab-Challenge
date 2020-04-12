using System;
using System.Collections.Generic;

namespace JokeGenerator
{
    public class RandomJokes : Jokes
    {
        private new readonly List<string> _listOfJokes;

        private Services _services { get; }

        public RandomJokes()
        {
            // we can use dependency injection
            _services = new Services();
            _listOfJokes = new List<string>();
        }
        public override void Builder()
        {
            SetNumberOfJokes();
            SetName();
            GetListOfJokes();
            PrintResult();
        }
    }
}
