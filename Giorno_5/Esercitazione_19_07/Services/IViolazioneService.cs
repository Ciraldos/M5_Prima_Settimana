using Esercitazione_19_07.Models;

namespace Esercitazione_19_07.Services
{
    public interface IViolazioneService
    {
        public IEnumerable<Violazione> GetAllViolazioni();
    }
}
