using ContactMobile.Models;
using System.Threading.Tasks;

namespace ContactMobile.Services
{
    public interface IAccountService 
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task Logout();
    }
}
