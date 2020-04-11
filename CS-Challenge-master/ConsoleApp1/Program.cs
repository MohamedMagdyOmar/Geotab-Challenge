using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JokeGenerator;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static ConsolePrinter printer = new ConsolePrinter();
        static Services services = new Services();
        static Utilities utilities = new Utilities();
        static List<string> listOfJokes = new List<string>();
        static int numberOfJokes;

        static void Main(string[] args)
        {
            Console.WriteLine("This Application generates jokes based on your choice:\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1- You can either choose random joke, or joke by category.");
            Console.WriteLine("2- Generated Joke can be by default name, or a name of your choice.");
            Console.WriteLine("3- You can choose the number of generated jokes.");
            Console.WriteLine("4- If your choice is not correct, default value will be selected automatically.");
            Console.WriteLine("5- After each choice you have to press ENTER, as a confirmation of you choice.\n");

            while (true)
            {
                Console.WriteLine("To Select Joke Type, please Press 'c' to show joke categories, or 'r' for random joke, then press ENTER");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() != "c" && userInput.ToLower() != "r")
                {
                    printer.Value("Inserted Value is not correct, joke by category is selected as default value").ToString();
                    userInput = "c";
                }

                if (userInput == "c")
                {
                    var jokesCategories = services.GetJokeCategories();
                    utilities.PrintResults(jokesCategories);
                    Console.WriteLine("please select one of the above categories by writing its name:");

                    string selectedJokeCategory = Console.ReadLine();
                    if (string.IsNullOrEmpty(selectedJokeCategory) || string.IsNullOrWhiteSpace(selectedJokeCategory))
                    {
                        printer.Value("No Category Selected, animal is selected as default category").ToString();
                        selectedJokeCategory = "animal";
                    }
                    else if (!jokesCategories.Contains(selectedJokeCategory.ToLower()))
                    {
                        printer.Value("wrong Category Selected, animal is selected as default category").ToString();
                        selectedJokeCategory = "animal";
                    }

                    Console.WriteLine("How many jokes do you want? press any number from (1 to 9):");
                    
                    if (!Int32.TryParse(Console.ReadLine(), out numberOfJokes))
                    {
                        printer.Value("Inserted Number Of Jokes is not correct, 1 is selected as default value").ToString();
                        numberOfJokes = 1;
                    }

                    if (numberOfJokes < 1 || numberOfJokes > 9)
                    {
                        printer.Value("Number Of Jokes selected is not between 1 and 9, 1 is selected as default value").ToString();
                        numberOfJokes = 1;
                    }

                    printer.Value("Want to use a random name? y/n").ToString();
                    string isRandomNameSelected = Console.ReadLine();

                    if (isRandomNameSelected == "y")
                    {
                        //GetNames();
                        listOfJokes = services.GetListOfJokesByCategoryAndDefaultName(numberOfJokes, selectedJokeCategory);
                    }

                    else
                    {
                        Console.WriteLine("Random Name is not selected\n");
                        printer.Value("Please Enter First Name: ").ToString();
                        string firstName = Console.ReadLine();

                        printer.Value("Please Enter Last Name: ").ToString();
                        string lastName = Console.ReadLine();
                        listOfJokes = services.GetListOfJokesByCategoryAndSpecificName(numberOfJokes, selectedJokeCategory, firstName, lastName);
                    }
                }

                else if (userInput == "r")
                {
                    Console.WriteLine("How many jokes do you want? press any number from (1 to 9):");

                    if (!Int32.TryParse(Console.ReadLine(), out numberOfJokes))
                    {
                        printer.Value("Inserted Number Of Jokes is not correct, 1 is selected as default value").ToString();
                        numberOfJokes = 1;
                    }

                    if (numberOfJokes < 1 || numberOfJokes > 9)
                    {
                        printer.Value("Number Of Jokes selected is not between 1 and 9, 1 is selected as default value").ToString();
                        numberOfJokes = 1;
                    }

                    printer.Value("Want to use a random name? y/n").ToString();
                    string isRandomNameSelected = Console.ReadLine();

                    if (isRandomNameSelected == "y")
                    {
                        //GetNames();
                        listOfJokes = services.GetListOfRandomJokesWithDefaultName(numberOfJokes);
                    }

                    else
                    {
                        Console.WriteLine("Random Name is not selected\n");
                        printer.Value("Please Enter First Name: ").ToString();
                        string firstName = Console.ReadLine();

                        printer.Value("Please Enter Last Name: ").ToString();
                        string lastName = Console.ReadLine();
                        listOfJokes = services.GetListOfRandomJokesWithSpecificName(numberOfJokes, firstName, lastName);
                    }
                }

                for(int i = 0; i < listOfJokes.Count; i++)
                {
                    Console.WriteLine((i + 1) + "-" + listOfJokes[i] + " \n");
                }
            }

        }
    }
}
