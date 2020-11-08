using QuizApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();

            var triviaService = DependencyService.Resolve<ITriviaService>();

            BindingContext = new QuizPageVM(triviaService);
        }
    }
}