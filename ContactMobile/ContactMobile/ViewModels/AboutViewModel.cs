using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ContactMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(() =>  OpenBrowser(new Uri ("http://microsoftdeveloper.com/")));
        }

        public static Task OpenBrowser(Uri uri)
        {
            return Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}