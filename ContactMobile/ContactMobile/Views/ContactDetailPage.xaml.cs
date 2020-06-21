using ContactMobile.Models;
using ContactMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        readonly ContactDetailViewModel viewModel;

        public ContactDetailPage(ContactDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ContactDetailPage()
        {
            InitializeComponent();

            var contact = new Contact
            {
                FirstName = "",
                LastName = "",
                MobileNo = "",
                EmailAddress = "",
                Address = ""
            };

            viewModel = new ContactDetailViewModel(contact);
            BindingContext = viewModel;
        }
    }
}