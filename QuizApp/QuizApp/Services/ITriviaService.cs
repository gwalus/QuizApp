using QuizApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp
{
    public interface ITriviaService
    {
        IList<Result> GetQuestions(string amount, string category, string difficulty, string type);
        Task<IList<TriviaCategory>> GetCategories();
    }
}
