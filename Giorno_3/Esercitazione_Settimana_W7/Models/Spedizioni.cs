namespace Esercitazione_Settimana_W7.Models
{
    public class Spedizioni
    {
        public int IdSpedizione { get; set; }
        public int? FK_ClienteAzienda { get; set; }
        public int? FK_ClientePrivato { get; set; }
        public int NumId { get; set; }
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }
        public string CittaDestinatario { get; set; }
        public string Indirizzo { get; set; }
        public string NomeDestinatario { get; set; }
        public decimal CostoSpedizione { get; set; }
        public DateTime DataConsegnaPrev { get; set; }
    }
}
