using Esercitazione_M5_Prima_Settimana.Services.Models;

namespace Esercitazione_M5_Prima_Settimana.Services
{
    public interface IAuthService
    {
        public ApplicationUser Login(string username, string password);
    }
}
