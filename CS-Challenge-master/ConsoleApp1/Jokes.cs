using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public abstract class Jokes
    {
        private readonly Services _services;
        private readonly Utilities _utilities;

        private int _numberOfJokes;
        private string _isRandomNameSelected;
        private Tuple<string, string> _names;
        protected List<string> _listOfJokes;

        public Jokes()
        {
            _services = new Services();
            _utilities = new Utilities();
        }
        protected void SetNumberOfJokes()
        {
            Console.WriteLine("How many jokes do you want? press any number from (1 to 9):");

            if (!Int32.TryParse(Console.ReadLine(), out _numberOfJokes))
            {
                Console.WriteLine("Inserted Number Of Jokes is not correct, 1 is selected as default value\n");
                _numberOfJokes = 1;
            }

            if (_numberOfJokes < 1 || _numberOfJokes > 9)
            {
                Console.WriteLine("Number Of Jokes selected is not between 1 and 9, 1 is selected as default value");
                _numberOfJokes = 1;
            }
        }

        protected void SetName()
        {
            Console.WriteLine("Want to use a random name? y/n");
            _isRandomNameSelected = Console.ReadLine();

            if (_isRandomNameSelected.ToLower() == "n" || _isRandomNameSelected.ToLower() == "no")
            {
                Console.WriteLine("Random Name is not selected\n");
                Console.WriteLine("Please Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Please Enter Last Name: ");
                string lastName = Console.ReadLine();
                _names = Tuple.Create(firstName, lastName);
            }
            else
            {
                Console.WriteLine("Random Name is selected\n");
                _names = _services.GetNames();
            }
        }

        protected void GetListOfJokes()
        {
            _listOfJokes = _services.GetListOfRandomJokes(_numberOfJokes, _names.Item1, _names.Item2);
        }

        protected void PrintResult()
        {
            for (int i = 0; i < _listOfJokes.Count; i++)
            {
                Console.WriteLine((i + 1) + "-" + _listOfJokes[i] + " \n");
            }
        }

        public abstract void Builder();
    }
}
