using QuizApp.Views;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
    public class WelcomePageVM
    {
        public WelcomePageVM()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://opentdb.com"));
            GoToQuizCommand = new Command(async () => await App.Current.MainPage.Navigation.PushAsync(new ChooseDetailQuizPage()));
        }

        public ICommand OpenWebCommand { get; set; }
        public ICommand GoToQuizCommand { get; set; }
    }
}
