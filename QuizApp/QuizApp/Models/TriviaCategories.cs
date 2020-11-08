using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class TriviaCategories
    {
        public IList<TriviaCategory> Trivia_categories { get; set; }
    }

    public class TriviaCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
