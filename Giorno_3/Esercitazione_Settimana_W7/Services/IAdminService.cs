using Esercitazione_Settimana_W7.Models;

namespace Esercitazione_Settimana_W7.Services
{
    public interface IAdminService
    {
        public IEnumerable<Spedizioni> GetAllShippings();
        public IEnumerable<Spedizioni> GetAllShippingsToday();
        public int GetAllShippingsAwaiting();
        public IEnumerable<SpedizioniCitta> GetAllShippingsByCity();
    }
}
