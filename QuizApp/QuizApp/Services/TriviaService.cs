using Newtonsoft.Json;
using QuizApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace QuizApp.Services
{
    public class TriviaService : ITriviaService
    {
        private Lazy<RestClient> client = new Lazy<RestClient>(() => new RestClient("https://opentdb.com/api.php?"));

        public IList<Result> GetQuestions(string amount, string category, string difficulty, string type)
        {
            var request = new RestRequest()
                .AddParameter("amount", $"{amount}")
                .AddParameter("category", $"{category}")
                .AddParameter("difficulty", $"{difficulty}")
                .AddParameter("type", $"{type}");

            var response = client.Value.Execute<TriviaResponse>(request);

            if (response.Data.response_code == 0)
                return response.Data.results;
            return null;
        }
    }
}
