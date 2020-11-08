using QuizApp.Models;
using System.Collections.Generic;

namespace QuizApp
{
    public interface ITriviaService
    {
        IList<Result> GetQuestions(string amount, string category, string difficulty, string type);
    }
}
