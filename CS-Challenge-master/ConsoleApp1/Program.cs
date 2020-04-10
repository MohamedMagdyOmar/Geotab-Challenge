using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static string[] results = new string[50];
        static char key;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();

        static void Main(string[] args)
        {
            printer.Value("Press ? to get instructions.").ToString();
            string userInput = Console.ReadLine();
            if (userInput != "?")
            {
                printer.Value("User Input Is Wrong, Default value ? has been selected ").ToString();
                userInput = "?";
            }
            if (userInput == "?")
            {
                while (true)
                {
                    printer.Value("Press c to get categories").ToString();
                    printer.Value("Press r to get random jokes").ToString();
                    GetEnteredKey(Console.ReadKey());
                    if (key == 'c')
                    {
                        getCategories();
                        PrintResults();

                        printer.Value("Enter a category;").ToString();
                        string jokeCategory = Console.ReadLine();
                        if (string.IsNullOrEmpty(jokeCategory) || string.IsNullOrWhiteSpace(jokeCategory))
                        {
                            printer.Value("No Category Selected, animal is selected as category").ToString();
                            jokeCategory = "animal";
                        }

                        printer.Value("How many jokes do you want? (1-9)").ToString();
                        int numberOfJokes = Int32.Parse(Console.ReadLine());
                        if (numberOfJokes < 1 || numberOfJokes > 9)
                        {
                            printer.Value("Number Of Jokes selected is not between 1 and 9, 1 is selected").ToString();
                            numberOfJokes = 1;
                        }

                        printer.Value("Want to use a random name? y/n").ToString();
                        GetEnteredKey(Console.ReadKey());
                        if (key == 'y')
                        {
                            GetNames();
                        }

                        else
                        {
                            printer.Value("Please Enter First Name: ").ToString();
                            string firstName = Console.ReadLine();

                            printer.Value("Please Enter Last Name: ").ToString();
                            string lastName = Console.ReadLine();
                            names = Tuple.Create(firstName, lastName);
                        }

                        GetJokesByCategory(jokeCategory, numberOfJokes);
                        PrintResults();
                    }

                    else if (key == 'r')
                    {
                        printer.Value("Want to use a random name? y/n").ToString();
                        GetEnteredKey(Console.ReadKey());
                        if (key == 'y')
                            GetNames();
                        printer.Value("Want to specify a category? y/n").ToString();
                        if (key == 'y')
                        {
                            printer.Value("How many jokes do you want? (1-9)").ToString();
                            int n = Int32.Parse(Console.ReadLine());
                            printer.Value("Enter a category;").ToString();
                            GetRandomJokes(Console.ReadLine(), n);
                            PrintResults();
                        }
                        else
                        {
                            printer.Value("How many jokes do you want? (1-9)").ToString();
                            int n = Int32.Parse(Console.ReadLine());
                            GetRandomJokes(null, n);
                            PrintResults();
                        }
                    }
                    names = null;
                }
            }

        }

        private static void PrintResults()
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
            }
        }

        private static void GetRandomJokes(string category, int number)
        {
            new JsonFeed("https://api.chucknorris.io/jokes/random", number);
            results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2);
        }

        private static void GetJokesByCategory(string category, int number)
        {
            new JsonFeed("https://api.chucknorris.io/jokes/random", number);
            results = JsonFeed.GetJokesByCategory(names?.Item1, names?.Item2, category);
        }

        private static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io/jokes/categories", 0);
            results = JsonFeed.GetCategories();
        }

        private static void GetNames()
        {
            new JsonFeed("https://randomuser.me/api/", 0);// "https://uinames.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
