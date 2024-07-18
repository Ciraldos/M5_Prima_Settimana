using Esercitazione_Settimana_W7.Models;
using Microsoft.Data.SqlClient;

namespace Esercitazione_Settimana_W7.Services
{
    public class AccountService : IAccountService
    {
        private string connectionstring;
        private const string COMMAND_IVA = "SELECT * FROM Spedizioni as SP JOIN ClientiAzienda as CA ON SP.FK_ClienteAzienda = CA.IdClienteAzienda WHERE CA.PIVA = @iva";
        private const string COMMAND_CF = "SELECT * FROM Spedizioni as SP JOIN ClientiPrivato as CP ON SP.FK_ClienteAzienda = CP.IdClientePriv WHERE CP.CF = @cf";

        public AccountService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }
        public Spedizioni GetSpedizioneByIva(string iva)
        {
            try
            {

                Spedizioni spedizioni = new Spedizioni();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_IVA, conn);
                cmd.Parameters.AddWithValue("@iva", iva);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    spedizioni.IdSpedizione = r.GetInt32(0);
                    spedizioni.FK_ClienteAzienda = r.IsDBNull(1) ? (int?)null : r.GetInt32(1);
                    spedizioni.FK_ClientePrivato = r.IsDBNull(2) ? (int?)null : r.GetInt32(2);
                    spedizioni.NumId = r.GetInt32(3);
                    spedizioni.DataSpedizione = r.GetDateTime(4);
                    spedizioni.Peso = r.GetDecimal(5);
                    spedizioni.CittaDestinatario = r.GetString(6);
                    spedizioni.Indirizzo = r.GetString(7);
                    spedizioni.NomeDestinatario = r.GetString(8);
                    spedizioni.CostoSpedizione = r.GetDecimal(9);
                    spedizioni.DataConsegnaPrev = r.GetDateTime(10);
                    return spedizioni;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public Spedizioni GetSpedizioneByCf(string cf)
        {
            try
            {

                Spedizioni spedizioni = new Spedizioni();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_CF, conn);
                cmd.Parameters.AddWithValue("@cf", cf);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    spedizioni.IdSpedizione = r.GetInt32(0);
                    spedizioni.FK_ClienteAzienda = r.IsDBNull(1) ? (int?)null : r.GetInt32(1);
                    spedizioni.FK_ClientePrivato = r.IsDBNull(2) ? (int?)null : r.GetInt32(2);
                    spedizioni.NumId = r.GetInt32(3);
                    spedizioni.DataSpedizione = r.GetDateTime(4);
                    spedizioni.Peso = r.GetDecimal(5);
                    spedizioni.CittaDestinatario = r.GetString(6);
                    spedizioni.Indirizzo = r.GetString(7);
                    spedizioni.NomeDestinatario = r.GetString(8);
                    spedizioni.CostoSpedizione = r.GetDecimal(9);
                    spedizioni.DataConsegnaPrev = r.GetDateTime(10);
                    return spedizioni;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
