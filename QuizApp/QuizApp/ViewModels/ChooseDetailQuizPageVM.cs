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

        private IList<int> categoriesQuantity;

        public IList<int> CategoriesQuantity
        {
            get { return categoriesQuantity; }
            set
            {
                categoriesQuantity = value;
                OnPropertyChanged("CategoriesQuantity");
            }
        }


        //private Dictionary<string, int> categories;

        //private Dictionary<string, int> Categories
        //{
        //    get { return categories; }
        //    set 
        //    {
        //        categories = value;
        //        OnPropertyChanged("Categories");
        //    }
        //}

        private bool loading = false;

        public bool Loading
        {
            get { return loading; }
            set 
            {
                loading = value;
                OnPropertyChanged("Loading");
            }
        }



        private readonly ITriviaService _triviaService;

        public event PropertyChangedEventHandler PropertyChanged;

        

        public ChooseDetailQuizPageVM(ITriviaService triviaService)
        {
            _triviaService = triviaService;
            //Categories = new Dictionary<string, int>();
            Categories = new List<TriviaCategory>();
            CategoriesQuantity = new List<int>();
            LoadCategories();
            ChooseCategoryCommand = new ChooseCategoryCommand(this);
        }

        public async void GoToQuiz(string categoryId)
        {
            await App.Current.MainPage.Navigation.PushAsync(new QuizPage(categoryId));
        }

        private async void LoadCategories()
        {
            Loading = true;
            var categories = await _triviaService.GetCategories();

            foreach (var category in categories)
            {
                var quantity = await _triviaService.GetCategoriesQuantity(category.Id.ToString());
                if (quantity != null)
                    CategoriesQuantity.Add(quantity.total_easy_question_count);                
            }

            Categories = categories;
            Loading = false;
        }

        private void OnPropertyChanged(string memberName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
