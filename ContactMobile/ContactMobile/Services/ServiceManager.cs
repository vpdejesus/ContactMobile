using System.Threading.Tasks;
using System.Collections.Generic;
using ContactMobile.Models;
using ContactMobile.Interfaces;

namespace ContactMobile.Services
{
    public class ServiceManager
    {
        private readonly IRestService _service;

        public ServiceManager(IRestService service)
        {
            _service = service;
        }

        public Task<List<Contact>> GetAllTaskAsync()
        {
            return _service.GetAllDataAsync();
        }

        public Task<Contact> GetTaskAsync(int id)
        {
            return _service.GetDataAsync(id);
        }

        public Task InsertTaskAsync(Contact contact)
        {
            return _service.InsertDataAsync(contact);
        }

        public Task UpdateTaskAsync(int id, Contact contact)
        {
            return _service.UpdateDataAsync(id, contact);
        }

        public Task DeleteTaskAsync(Contact contact)
        {
            return _service.DeleteDataAsync(contact.Id);
        }
    }
}
