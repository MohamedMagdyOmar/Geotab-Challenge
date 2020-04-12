using System;
using JokeGenerator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            // we can use logging, but i did not log anything to keep the console clean
            var serviceProvider = new ServiceCollection().AddLogging(cfg => cfg.AddConsole()).Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Debug).BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            while (true)
            {
                try
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
                            //logger.LogDebug("User Selected Random Joke");
                            RandomJokes randomJoke = new RandomJokes();
                            randomJoke.Builder();
                            break;
                        default:
                            //logger.LogDebug("User Selected wrong choice" + userInput);
                            Console.WriteLine("Inserted Value is not correct, random joke is selected as default value\n");
                            RandomJokes joke = new RandomJokes();
                            joke.Builder();
                            break;
                    }
                }
                catch(Exception e)
                {
                    logger.LogDebug("Unexpected Error\n");
                    logger.LogDebug(e.Message);
                }
                
            }

        }
    }
}
