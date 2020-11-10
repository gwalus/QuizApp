using QuizApp.Services;
using QuizApp.Views;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ITriviaService, TriviaService>();

            //Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));

            //Device.SetFlags(new string[] { "Shapes_Experimental" });

            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
