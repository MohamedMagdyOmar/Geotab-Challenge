using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokeGenerator
{
    public class JokesController
    {
        private Utilities _utilities;
        private string _url;
        string requestUri = "jokes/random";
        Tuple<string, string> names;
        int _resultIndex = 0;
        public JokesController()
        {
            // we can use dependency injection, but since the solution is simple there is no need for over engineering
            _utilities = new Utilities();
        }

        public string GetRandomJokes()
        {
            HttpClient _client = new HttpClient();
            _url = "https://api.chucknorris.io";
            _client.BaseAddress = new Uri(_url);
            return Convert.ToString(JsonConvert.DeserializeObject<dynamic>(Task.FromResult(_client.GetStringAsync(requestUri).Result).Result).value);
        }

        public string GetJokesByCategory(string jokeCategory)
        {           
            HttpClient _client = new HttpClient();
            _url = "https://api.chucknorris.io";
            _client.BaseAddress = new Uri(_url);

            requestUri = _utilities.AppendJokeCategory(requestUri, jokeCategory);
            return Convert.ToString(JsonConvert.DeserializeObject<dynamic>(Task.FromResult(_client.GetStringAsync(requestUri).Result).Result).value);
        }

        public List<string> GetAllJokesCategories()
        {
            _url = "https://api.chucknorris.io/jokes/categories";
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(_url);
            return JsonConvert.DeserializeObject<List<string>>(Task.FromResult(_client.GetStringAsync("categories").Result).Result);
        }

        public Tuple<string, string> GetNames()
        {
            _url = "https://randomuser.me/api/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            var result = JsonConvert.DeserializeObject<dynamic>(client.GetStringAsync("").Result);
            return Tuple.Create(Convert.ToString(result.results[_resultIndex].name.first), Convert.ToString(result.results[_resultIndex].name.last));
        }
    }
}
