using System;
using System.Collections.Generic;
using System.Text;

namespace JokeGenerator
{
    public class CategoryJokes : Jokes
    {
        readonly Services _services;
        readonly Utilities _utilities;

        private List<string> _jokesCategories;
        private string _selectedJokeCategory;
        public CategoryJokes()
        {
            // we can use dependency injection
            _services = new Services();
            _utilities = new Utilities();
            _listOfJokes = new List<string>();
            _jokesCategories = new List<string>();
        }

        protected void GetJokeCategories()
        {
            _jokesCategories = _services.GetJokeCategories();
            _utilities.PrintResults(_jokesCategories);
        }
        protected void SetCategory()
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
        public override void Builder()
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
