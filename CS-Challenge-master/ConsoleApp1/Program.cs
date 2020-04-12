using System;
using JokeGenerator;

namespace ConsoleApp1
{
    class Program
    {
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
                Console.WriteLine("To Select Joke Type, please Press 'c' to show joke categories, or 'r' for random joke, then press ENTER\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "c":
                        CategoryJokes jokeByCategory = new CategoryJokes();
                        jokeByCategory.Builder();
                        break;
                    case "r":
                        RandomJokes randomJoke = new RandomJokes();
                        randomJoke.Builder();
                        break;
                    default:
                        Console.WriteLine("Inserted Value is not correct, random joke is selected as default value\n");
                        RandomJokes joke = new RandomJokes();
                        joke.Builder();
                        break;
                }
            }

        }
    }
}
