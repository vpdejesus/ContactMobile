using System;
using ContactMobile.Models;
using ContactMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        readonly ContactsViewModel viewModel;

        public ContactsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ContactsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var contact = args.SelectedItem as Contact;
            if (contact == null)
                return;

            await Navigation.PushAsync(new ContactDetailPage(new ContactDetailViewModel(contact)));
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Contacts.Count == 0)
                viewModel.LoadCommand.Execute(null);
        }

        async void AddContact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewContactPage()));
        }

        async void EditContact_Clicked(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var contact = menu?.BindingContext as Contact;
            await Navigation.PushModalAsync(new NavigationPage(new EditContactPage(new ContactDetailViewModel(contact))));
        }

        private void DeleteContact_Clicked(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var contact = menu?.BindingContext as Contact;
            var viewModel = BindingContext as ContactsViewModel;
            viewModel?.DeleteCommand.Execute(contact);
        }
    }
}