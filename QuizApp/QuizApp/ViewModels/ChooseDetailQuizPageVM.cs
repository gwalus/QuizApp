using QuizApp.Models;
using QuizApp.ViewModels.Commands;
using QuizApp.Views;
using System.Collections.Generic;
using System.ComponentModel;

namespace QuizApp.ViewModels
{
    public class ChooseDetailQuizPageVM : INotifyPropertyChanged
    {
        public ChooseCategoryCommand ChooseCategoryCommand { get; set; }

        private IList<TriviaCategory> categories;
        public IList<TriviaCategory> Categories 
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }        

        private readonly ITriviaService _triviaService;

        public event PropertyChangedEventHandler PropertyChanged;

        

        public ChooseDetailQuizPageVM(ITriviaService triviaService)
        {
            _triviaService = triviaService;
            LoadCategories();
            ChooseCategoryCommand = new ChooseCategoryCommand(this);
        }

        public async void GoToQuiz(string categoryId)
        {
            await App.Current.MainPage.Navigation.PushAsync(new QuizPage(categoryId));
        }

        private async void LoadCategories()
        {
            var categories = await _triviaService.GetCategories();
            Categories = categories;
        }

        private void OnPropertyChanged(string memberName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
