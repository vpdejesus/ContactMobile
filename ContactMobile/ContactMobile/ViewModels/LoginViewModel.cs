using System.Windows.Input;
using Xamarin.Forms;
using ContactMobile.Models;
using ContactMobile.Helpers;

namespace ContactMobile.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var model = new LoginModel
                    {
                        Email = Username,
                        Password = Password,
                        RememberMe = false
                    };

                    // Authenticate user by calling LoginAsync service
                    await App.AuthManager.LoginAsync(model);

                    // If Token is returned after logging in, launch MasterDetailPage
                    if (!string.IsNullOrEmpty(Settings.AccessToken))
                        MessagingCenter.Send<object>(this, App.LAUNCH_MAIN_PAGE);
                });
            }
        }

        public ICommand OpenRegisterCommand
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Send<object>(this, App.LAUNCH_REGISTER_PAGE);
                });
            }
        }
    }
}
