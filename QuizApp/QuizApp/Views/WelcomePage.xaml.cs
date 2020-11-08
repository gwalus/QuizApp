using QuizApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            BindingContext = new WelcomePageVM();
        }
    }
}