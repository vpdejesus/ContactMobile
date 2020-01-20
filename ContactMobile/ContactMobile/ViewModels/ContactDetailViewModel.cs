using ContactMobile.Models;

namespace ContactMobile.ViewModels
{
    public class ContactDetailViewModel : BaseViewModel
    {
        public Contact Contact { get; set; }

        public ContactDetailViewModel(Contact contact = null)
        {
            Title = contact?.FirstName + " " + contact?.LastName;
            Contact = contact;
        }
    }
}
