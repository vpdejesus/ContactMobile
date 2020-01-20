using ContactMobile.Models;
using System.Threading.Tasks;

namespace ContactMobile.Services
{
    public class AuthManager
    {
        private readonly IAccountService _service;

        public AuthManager(IAccountService service)
        {
            _service = service;
        }

        public Task<LoginResult> LoginAsync(LoginModel model)
        {
            return _service.Login(model);
        }

        public Task<RegisterResult> RegisterAsync(RegisterModel model)
        {
            return _service.Register(model);
        }

        public void Logout()
        {
            _service.Logout();
        }
    }
}
