using QuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseDetailQuizPage : ContentPage
    {
        public ChooseDetailQuizPage()
        {
            InitializeComponent();

            var triviaService = DependencyService.Resolve<ITriviaService>();

            BindingContext = new ChooseDetailQuizPageVM(triviaService);
        }
    }
}