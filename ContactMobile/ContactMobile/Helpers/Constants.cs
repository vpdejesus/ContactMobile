using Xamarin.Forms;

namespace ContactMobile.Helpers
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "http://192.168.144.2:88" : "http://cmservice.com";
        public static string ApiAddress = "/api/contacts/{0}";
        public static string ContactsUrl = BaseAddress + ApiAddress;
    }
}
