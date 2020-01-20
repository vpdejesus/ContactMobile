using System;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using ContactMobile.Models;
using ContactMobile.Helpers;
using ContactMobile.Interfaces;

namespace ContactMobile.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<Contact>> GetAllDataAsync()
        {
            var contacts = new List<Contact>();
            var uri = new Uri(string.Format(Constants.ContactsUrl, string.Empty));
            var auth = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            _client.DefaultRequestHeaders.Authorization = auth;

            try
            {
                var response = await _client.GetAsync(uri); 

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return contacts;
        }

        public async Task<Contact> GetDataAsync(int id)
        {
            var contact = new Contact();
            var uri = new Uri(string.Format(Constants.ContactsUrl, id));
            var auth = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            _client.DefaultRequestHeaders.Authorization = auth;

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contact = JsonConvert.DeserializeObject<Contact>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return contact;
        }

        public async Task InsertDataAsync(Contact contact)
        {
            var uri = new Uri(string.Format(Constants.ContactsUrl, string.Empty));
            var auth = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            _client.DefaultRequestHeaders.Authorization = auth;

            try
            {
                var json = JsonConvert.SerializeObject(contact);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tContact successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task UpdateDataAsync(int id, Contact contact)
        {
            var uri = new Uri(string.Format(Constants.ContactsUrl, id));
            var auth = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            _client.DefaultRequestHeaders.Authorization = auth;

            try
            {
                var json = JsonConvert.SerializeObject(contact);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tContact successfully updated.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteDataAsync(int id)
        {
            var uri = new Uri(string.Format(Constants.ContactsUrl, id));
            var auth = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
            _client.DefaultRequestHeaders.Authorization = auth;

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
