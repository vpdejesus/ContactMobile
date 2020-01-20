using Xamarin.Forms;
using ContactMobile.Views;
using ContactMobile.Helpers;
using ContactMobile.Services;

namespace ContactMobile
{
    public partial class App : Application
    {
        public static AuthManager AuthManager { get; private set; }
        public static ServiceManager ServiceManager { get; private set; }

        public static string LAUNCH_MAIN_PAGE = "LAUNCH_MAIN_PAGE";
        public static string LAUNCH_LOGIN_PAGE = "LAUNCH_LOGIN_PAGE";
        public static string LAUNCH_REGISTER_PAGE = "LAUNCH_REGISTER_PAGE";

        public App()
        {
            InitializeComponent();
            AuthManager = new AuthManager(new AccountService());
            ServiceManager = new ServiceManager(new RestService());

            // Message Center Subscription
            MessagingCenter.Subscribe<object>(this, LAUNCH_MAIN_PAGE, OpenMainPage);
            MessagingCenter.Subscribe<object>(this, LAUNCH_LOGIN_PAGE, OpenLoginPage);
            MessagingCenter.Subscribe<object>(this, LAUNCH_REGISTER_PAGE, OpenRegisterPage);
            // Set MainPage 
            SetMainPage();
        }

        private void SetMainPage()
        {
            if (string.IsNullOrEmpty(Settings.AccessToken))
            {
                MainPage = new LoginPage();
            }
            else 
            {
                MainPage = new MainPage();
            }
        }

        private void OpenMainPage(object sender)
        {
            MainPage = new MainPage();
        }

        private void OpenLoginPage(object sender)
        {
            MainPage = new LoginPage();
        }

        private void OpenRegisterPage(object sender)
        {
            MainPage = new RegisterPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
