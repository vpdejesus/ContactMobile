using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ContactMobile.Views;
using ContactMobile.Models;

namespace ContactMobile.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public Command LoadCommand { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactsViewModel()
        {
            Title = "Contacts";
            Contacts = new ObservableCollection<Contact>();
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            
            MessagingCenter.Subscribe<NewContactPage, Contact>(this, "AddContact", async (obj, contact) =>
            {
                var newContact = contact as Contact;
                Contacts.Add(newContact);
                await App.ServiceManager.InsertTaskAsync(newContact);
            });

            MessagingCenter.Subscribe<EditContactPage, Contact>(this, "EditContact", async (obj, contact) =>
            {
                var editContact = contact as Contact;
                await App.ServiceManager.UpdateTaskAsync(editContact.Id, editContact);
                await ExecuteLoadCommand();
            });
        }

        public Command<Contact> DeleteCommand
        {
            get
            {
                return new Command<Contact>((contact) =>
                {
                    Contacts.Remove(contact);
                    App.ServiceManager.DeleteTaskAsync(contact);
                });
            }
        }

        async Task ExecuteLoadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Contacts.Clear();
                var contacts = await App.ServiceManager.GetAllTaskAsync();

                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
