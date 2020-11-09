using QuizApp.ViewModels;

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