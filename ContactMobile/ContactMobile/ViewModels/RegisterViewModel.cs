using System.Windows.Input;
using Xamarin.Forms;
using ContactMobile.Helpers;
using ContactMobile.Models;

namespace ContactMobile.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var model = new RegisterModel
                    {
                        Email = Username,
                        Password = Password,
                        ConfirmPassword = ConfirmPassword
                    };

                    if (!Utilities.IsValidEmail(Username))
                    {
                        Message = "Username is not a valid email.";
                    }
                    else if (!Utilities.IsValidPassword(Password))
                    {
                        Message = "Password must be 6 characters long, contains at least 1 uppercase, lowercase letters and a special character.";
                    }
                    else if (Password != ConfirmPassword)
                    {
                        Message = "Password and confirm password should be the same.";
                    }
                    else
                    {
                        var result = await App.AuthManager.RegisterAsync(model);

                        Settings.Username = Username;
                        Settings.Password = Password;

                        Message = result.Successful ? "Registration successful!" : "Registration unsuccessful! Try again.";
                    }
                });
            }
        }

        public ICommand OpenLoginCommand
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Send<object>(this, App.LAUNCH_LOGIN_PAGE);
                });
            }
        }

    }
}
