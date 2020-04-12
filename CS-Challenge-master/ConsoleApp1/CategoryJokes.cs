using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public class CategoryJokes : IJokes
    {
        readonly Services _services;
        readonly Utilities _utilities;

        private int _numberOfJokes;
        private List<string> _jokesCategories;
        private string _selectedJokeCategory;
        private string _isRandomNameSelected;
        private Tuple<string, string> _names;
        private List<string> _listOfJokes;
        public CategoryJokes()
        {
            // we can use dependency injection
            _services = new Services();
            _utilities = new Utilities();
            _listOfJokes = new List<string>();
            _jokesCategories = new List<string>();
        }

        private void GetJokeCategories()
        {
            _jokesCategories = _services.GetJokeCategories();
            _utilities.PrintResults(_jokesCategories);
        }
        private void SetCategory()
        {
            Console.WriteLine("please select one of the above categories by writing its name:");

            _selectedJokeCategory = Console.ReadLine();
            if (string.IsNullOrEmpty(_selectedJokeCategory) || string.IsNullOrWhiteSpace(_selectedJokeCategory))
            {
                Console.WriteLine("No Category Selected, animal is selected as default category");
                _selectedJokeCategory = "animal";
            }
            else if (!_jokesCategories.Contains(_selectedJokeCategory.ToLower()))
            {
                Console.WriteLine("wrong Category Selected, animal is selected as default category");
                _selectedJokeCategory = "animal";
            }
        }
        public void SetNumberOfJokes()
        {
            Console.WriteLine("How many jokes do you want? press any number from (1 to 9):");

            if (!Int32.TryParse(Console.ReadLine(), out _numberOfJokes))
            {
                Console.WriteLine("Inserted Number Of Jokes is not correct, 1 is selected as default value");
                _numberOfJokes = 1;
            }

            if (_numberOfJokes < 1 || _numberOfJokes > 9)
            {
                Console.WriteLine("Number Of Jokes selected is not between 1 and 9, 1 is selected as default value");
                _numberOfJokes = 1;
            }
        }
        public void SetName()
        {
            Console.WriteLine("Want to use a random name? y/n");
            _isRandomNameSelected = Console.ReadLine();

            if(_isRandomNameSelected.ToLower() == "n" || _isRandomNameSelected.ToLower() == "no")
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
        private void GetListOfJokes()
        {
            _listOfJokes = _services.GetListOfJokesByCategory(_numberOfJokes, _selectedJokeCategory, _names.Item1, _names.Item2);
        }      
        public void PrintResult()
        {
            for (int i = 0; i < _listOfJokes.Count; i++)
            {
                Console.WriteLine((i + 1) + "-" + _listOfJokes[i] + " \n");
            }
        }
        public void Builder()
        {
            GetJokeCategories();
            SetCategory();
            SetNumberOfJokes();
            SetName();
            GetListOfJokes();
            PrintResult();
        }
    }
}
