using QuizApp.Models;
using QuizApp.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

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

        private int currentNumberQuestion = 0;

        public int CurrentNumberQuestion
        {
            get { return currentNumberQuestion; }
            set
            {
                currentNumberQuestion = value;
                OnPropertyChanged("CurrentNumberQuestion");
            }
        }

        private Result currentQuestion;

        public Result CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; }
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

        private int score = 0;

        public int Score
        {
            get { return score; }
            set 
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }


        private int questionsCount;
        public CheckAnswerCommand CheckAnswerCommand { get; set; }
        private readonly ITriviaService _triviaService;

        public QuizPageVM(ITriviaService triviaService, string chosedCategory)
        {
            _triviaService = triviaService;
            GetQuestions(chosedCategory);
            GetOneQuestion(CurrentNumberQuestion);
            CheckAnswerCommand = new CheckAnswerCommand(this);
        }

        public void GetQuestions(string categoryId)
        {
            var questions = _triviaService.GetQuestions("5", categoryId, "easy", "multiple");

            if (questions != null)
            {
                Questions = questions;
                questionsCount = Questions.Count();
            }
        }

        public void GetOneQuestion(int current)
        {
            CurrentQuestion = Questions.ElementAt(current);
            // aktualny zestaw pytania

            Question = CurrentQuestion.question;
            // aktualne pytanie STRING

            var listOfAnswers = new List<string>(CurrentQuestion.incorrect_answers);
            listOfAnswers.Add(CurrentQuestion.correct_answer);
            // lista odpowiedzi obecnego pytania

            var numbers = new List<int>() { 0, 1, 2, 3 };
            var mixedNumbers = numbers.OrderBy(a => Guid.NewGuid()).ToList();
            // losowo ustawiane odpowiedzi, tak żeby poprawna odpowiedź nie była zawsze w tym samym miejscu

            Answer1 = listOfAnswers.ElementAt(mixedNumbers[0]);
            Answer2 = listOfAnswers.ElementAt(mixedNumbers[1]);
            Answer3 = listOfAnswers.ElementAt(mixedNumbers[2]);
            Answer4 = listOfAnswers.ElementAt(mixedNumbers[3]);
        }

        public void CheckAnswer(string userAnswer)
        {
            if (CurrentQuestion.correct_answer == userAnswer)
                Score += 1;
        }

        private void OnPropertyChanged(string memberName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
