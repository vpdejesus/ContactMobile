using System.Threading.Tasks;
using System.Collections.Generic;
using ContactMobile.Models;

namespace ContactMobile.Interfaces
{
    public interface IRestService
    {
        Task<List<Contact>> GetAllDataAsync();
        
        Task<Contact> GetDataAsync(int id);

        Task InsertDataAsync(Contact contact);

        Task UpdateDataAsync(int id, Contact contact);

        Task DeleteDataAsync(int id);
    }
}
