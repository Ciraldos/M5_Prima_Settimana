using Esercitazione_19_07.Models;

namespace Esercitazione_19_07.Services
{
    public interface IVerbaleService
    {
        public Verbale CreateVerbale(Verbale verbale);
        public IEnumerable<VerbaleTrasgressore> GetVerbaliByTrasgressore();
        public IEnumerable<VerbaleTrasgressore> GetPuntiByTrasgressore();
        public List<ViolazionePuntiDieci> GetViolazioniSuperioriDieciPunti();
        public List<VerbaleAnagrafico> GetViolazioniSuperioriEuro();


    }
}
