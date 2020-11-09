using QuizApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class TriviaService : ITriviaService
    {
        private readonly Lazy<RestClient> client = new Lazy<RestClient>(() => new RestClient("https://opentdb.com/api.php?"));

        public async Task<IList<TriviaCategory>> GetCategories()
        {
            var request = new RestRequest("https://opentdb.com/api_category.php");

            var response = await client.Value.ExecuteAsync<TriviaCategories>(request);

            if (response.IsSuccessful)
                return response.Data.Trivia_categories;
            return null;
        }

        public IList<Result> GetQuestions(string amount, string categoryId, string difficulty, string type)
        {
            var request = new RestRequest()
                .AddParameter("amount", $"{amount}")
                .AddParameter("category", $"{categoryId}")
                .AddParameter("difficulty", $"{difficulty}")
                .AddParameter("type", $"{type}");

            var response = client.Value.Execute<TriviaResponse>(request);
            // sync

            if (response.IsSuccessful)
                return response.Data.results;

            return null;
        }
    }
}
