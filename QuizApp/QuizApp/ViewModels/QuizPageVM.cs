using QuizApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuizApp.ViewModels
{
    public class QuizPageVM : INotifyPropertyChanged
    {
        public IList<Result> Questions { get; set; }

        private string question;

        public string Question
        {
            get { return question; }
            set 
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }


        private string answer1;

        public string Answer1
        {
            get { return answer1; }
            set 
            {
                answer1 = value;
                OnPropertyChanged("Answer1");
            }
        }

        private string answer2;

        public string Answer2
        {
            get { return answer2; }
            set 
            {
                answer2 = value;
                OnPropertyChanged("Answer2");
            }
        }

        private string answer3;

        public string Answer3
        {
            get { return answer3; }
            set
            {
                answer3 = value;
                OnPropertyChanged("Answer3");
            }
        }

        private string answer4;

        public string Answer4
        {
            get { return answer4; }
            set
            {
                answer4 = value;
                OnPropertyChanged("Answer4");
            }
        }


        private readonly ITriviaService _triviaService;

        public QuizPageVM(ITriviaService triviaService, string chosedCategory)
        {
            _triviaService = triviaService;
            GetQuestions(chosedCategory);
            GetOneQuestion();
        }

        public async void GetQuestions(string categoryId)
        {
            Questions = await _triviaService.GetQuestions("10", categoryId, "easy", "multiple");
        }

        public void GetOneQuestion()
        {
            var currentQuestion = Questions.FirstOrDefault();

            Question = currentQuestion.question;
            Answer1 = currentQuestion.incorrect_answers.ElementAt(0);
            Answer2 = currentQuestion.incorrect_answers.ElementAt(1);
            Answer3 = currentQuestion.incorrect_answers.ElementAt(2);
            Answer4 = currentQuestion.correct_answer;
        }

        private void OnPropertyChanged(string memberName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
