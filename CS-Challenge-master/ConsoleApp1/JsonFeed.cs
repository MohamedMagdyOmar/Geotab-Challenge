using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
	class JsonFeed
	{
		static string _url = "";
		static int numberOfJokes;

		public JsonFeed() { }
		public JsonFeed(string endpoint, int results)
		{
			_url = endpoint;
			numberOfJokes = results;
		}

		public static string[] GetRandomJokes(string firstname, string lastname)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			string url = "jokes/random";
			List<string> listOfJokes = new List<string>();
			for (int i = 0; i < numberOfJokes; i++)
			{
				string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

				if (firstname != null && lastname != null)
				{
					int index = joke.IndexOf("Chuck Norris");
					string firstPart = joke.Substring(0, index);
					string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
					joke = firstPart + " " + firstname + " " + lastname + secondPart;
				}
				listOfJokes.Add(JsonConvert.DeserializeObject<dynamic>(joke).value);
			}


			return listOfJokes.ToArray();
		}

		public static string[] GetJokesByCategory(string firstname, string lastname, string category)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			List<string> listOfJokes = new List<string>();
			string url = "https://api.chucknorris.io/jokes/random";
			if (category != null)
			{
				if (url.Contains('?'))
					url += "&";
				else url += "?";
				url += "category=";
				url += category;
			}

			for (int i = 0; i < numberOfJokes; i++)
			{
				string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

				if (firstname != null && lastname != null)
				{
					// validate if it comes at the end of the sentence, or at the beginning of a sentence, or did not come at all
					int index = joke.IndexOf("Chuck Norris");
					string firstPart = joke.Substring(0, index);
					string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
					joke = firstPart + " " + firstname + " " + lastname + secondPart;
				}
				
				listOfJokes.Add(Convert.ToString(JsonConvert.DeserializeObject<dynamic>(joke).value));
			}

			return listOfJokes.ToArray();
		}

		/// <summary>
		/// returns an object that contains name and surname
		/// </summary>
		/// <param name="client2"></param>
		/// <returns></returns>
		public static dynamic Getnames()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);

			//var result1 = Task.FromResult(client.GetStringAsync("name").Result).Result;
			var result = client.GetStringAsync("results").Result;
			return JsonConvert.DeserializeObject<dynamic>(result);
		}

		public static string[] GetCategories()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			//var result = Task.FromResult(client.GetStringAsync("categories").Result).Result;
			return JsonConvert.DeserializeObject<string[]>(Task.FromResult(client.GetStringAsync("categories").Result).Result);
			//return new string[] { Task.FromResult(client.GetStringAsync("categories").Result).Result };
		}
	}
}
