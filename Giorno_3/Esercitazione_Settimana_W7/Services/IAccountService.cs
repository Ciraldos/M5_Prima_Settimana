using Esercitazione_Settimana_W7.Models;

namespace Esercitazione_Settimana_W7.Services
{
    public interface IAccountService
    {
        public Spedizioni GetSpedizioneByIva(string iva);
        public Spedizioni GetSpedizioneByCf(string cf);

    }
}
