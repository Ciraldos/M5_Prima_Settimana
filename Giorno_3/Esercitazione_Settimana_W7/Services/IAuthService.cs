using Esercitazione_Settimana_W7.Models;

namespace Esercitazione_Settimana_W7.Services
{
    public interface IAuthService
    {
        public Users Login(string username, string password);
        public Users Register(string username, string password);

    }
}
