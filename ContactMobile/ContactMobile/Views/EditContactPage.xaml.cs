using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactMobile.Models;
using ContactMobile.ViewModels;

namespace ContactMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        ContactDetailViewModel viewModel;
        public Contact Contact { get; set; }

        public EditContactPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public EditContactPage()
        {
            InitializeComponent();

            var Contact = new Contact
            {
                FirstName = "",
                LastName = "",
                MobileNo = "",
                EmailAddress = "",
                Address = ""
            };

            viewModel = new ContactDetailViewModel(Contact);
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditContact", viewModel.Contact);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}