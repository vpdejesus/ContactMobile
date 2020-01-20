using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ContactMobile.Models;
using ContactMobile.Helpers;

namespace ContactMobile.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        public AccountService()
        {
            _client = new HttpClient();
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            return content;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var uri = new Uri(string.Format(Constants.BaseAddress + "/api/login", string.Empty));
            var response = await _client.PostAsync(uri, GetStringContentFromObject(loginModel));
            var result = JsonConvert.DeserializeObject<LoginResult>(await response.Content.ReadAsStringAsync());

            if (!response.IsSuccessStatusCode)
            {
                return result;
            }

            Settings.AccessToken = result.Token;
            return result;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var uri = new Uri(string.Format(Constants.BaseAddress + "/api/register", string.Empty));
            var response = await _client.PostAsync(uri, GetStringContentFromObject(registerModel));
            var result = JsonConvert.DeserializeObject<RegisterResult>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task Logout()
        {
            Settings.AccessToken = "";
            _client.DefaultRequestHeaders.Authorization = null;
            await Task.Delay(10000);
        }
    }
}
