using W7.D2.WebAuthentication.Services.Models;

namespace W7.D2.WebAuthentication.Services
{
    public interface IAuthService
    {
        ApplicationUser Login(string username, string password);
    }
}
