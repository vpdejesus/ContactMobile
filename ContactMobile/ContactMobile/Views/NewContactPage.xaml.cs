using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactMobile.Models;

namespace ContactMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewContactPage : ContentPage
    {
        public Contact Contact { get; set; }
        
        public NewContactPage()
        {
            InitializeComponent();

            Contact = new Contact
            {
                FirstName = "",
                LastName = "",
                MobileNo = "",
                EmailAddress = "",
                Address = ""
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddContact", Contact);            
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}