using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    public class JokesController
    {
        private HttpClient _client;
        private Utilities _utilities;
        private string _url;
        public JokesController()
        {
            _url = "https://api.chucknorris.io/jokes/random";
            _client = new HttpClient();

            // we can use dependency injection, but since the solution is simple there is no need for over engineering
            _utilities = new Utilities();
        }

        public string GetRandomJokes()
        {            
            _client.BaseAddress = new Uri(_url);
            return Task.FromResult(_client.GetStringAsync(_url).Result).Result;
        }

        public string GetJokesByCategory(string jokeCategory)
        {
            _url = _utilities.AppendJokeCategory(_url, jokeCategory);
            return Task.FromResult(_client.GetStringAsync(_url).Result).Result;
        }

        public string[] GetAllJokesCategory()
        {
            _url = "https://api.chucknorris.io/jokes/categories";
            _client.BaseAddress = new Uri(_url);
            return JsonConvert.DeserializeObject<string[]>(Task.FromResult(_client.GetStringAsync("categories").Result).Result);
        }
    }
}
