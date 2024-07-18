using Esercitazione_Settimana_W7.Models;
using Microsoft.Data.SqlClient;

namespace Esercitazione_Settimana_W7.Services
{
    public class AdminService : IAdminService
    {
        private string connectionstring;
        private const string ALL_SHIPPINGS = "SELECT * FROM Spedizioni";
        private const string SHIPPINGS_TODAY = "SELECT * FROM Spedizioni AS SP JOIN StatoSpedizione AS SS ON SP.IdSpedizione = SS.FK_IdSpedizione WHERE SS.Stato = 'In consegna' AND CONVERT(date, SP.DataConsegnaPrev) = @date";
        private const string SHIPPINGS_AWAITING = "SELECT COUNT(*) FROM StatoSpedizione WHERE Stato = 'In Attesa'";
        private const string SHIPPINGS_BY_CITY = "SELECT CittaDestinatario, COUNT(*) FROM Spedizioni GROUP BY CittaDestinatario";



        public AdminService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }
        public IEnumerable<Spedizioni> GetAllShippings()
        {
            {
                try
                {
                    List<Spedizioni> s = new List<Spedizioni>();
                    using var conn = new SqlConnection(connectionstring);
                    conn.Open();
                    using var cmd = new SqlCommand(ALL_SHIPPINGS, conn);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Spedizioni spedizione = new Spedizioni();
                        {
                            spedizione.IdSpedizione = reader.GetInt32(0);
                            spedizione.FK_ClienteAzienda = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                            spedizione.FK_ClientePrivato = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                            spedizione.NumId = reader.GetInt32(3);
                            spedizione.DataSpedizione = reader.GetDateTime(4);
                            spedizione.Peso = reader.GetDecimal(5);
                            spedizione.CittaDestinatario = reader.GetString(6);
                            spedizione.Indirizzo = reader.GetString(7);
                            spedizione.NomeDestinatario = reader.GetString(8);
                            spedizione.CostoSpedizione = reader.GetDecimal(9);
                            spedizione.DataConsegnaPrev = reader.GetDateTime(10);
                        };
                        s.Add(spedizione);
                    }
                    return s;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante il recupero delle spedizioni: {ex.Message}");
                    throw;
                }
            }
        }

        public IEnumerable<Spedizioni> GetAllShippingsToday()
        {
            {
                try
                {
                    List<Spedizioni> s = new List<Spedizioni>();
                    using var conn = new SqlConnection(connectionstring);
                    conn.Open();
                    using var cmd = new SqlCommand(SHIPPINGS_TODAY, conn);
                    var date = DateTime.Today;
                    cmd.Parameters.AddWithValue("@date", date);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Spedizioni spedizione = new Spedizioni();
                        {
                            spedizione.IdSpedizione = reader.GetInt32(0);
                            spedizione.FK_ClienteAzienda = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1);
                            spedizione.FK_ClientePrivato = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2);
                            spedizione.NumId = reader.GetInt32(3);
                            spedizione.DataSpedizione = reader.GetDateTime(4);
                            spedizione.Peso = reader.GetDecimal(5);
                            spedizione.CittaDestinatario = reader.GetString(6);
                            spedizione.Indirizzo = reader.GetString(7);
                            spedizione.NomeDestinatario = reader.GetString(8);
                            spedizione.CostoSpedizione = reader.GetDecimal(9);
                            spedizione.DataConsegnaPrev = reader.GetDateTime(10);
                        };
                        s.Add(spedizione);
                    }
                    return s;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante il recupero delle spedizioni: {ex.Message}");
                    throw;
                }
            }
        }

        public int GetAllShippingsAwaiting()
        {
            try
            {
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(SHIPPINGS_AWAITING, conn);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il conteggio delle spedizioni in attesa: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<SpedizioniCitta> GetAllShippingsByCity()
        {
            try
            {
                List<SpedizioniCitta> sc = new List<SpedizioniCitta>();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(SHIPPINGS_BY_CITY, conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    SpedizioniCitta s = new SpedizioniCitta();
                    s.CityName = r.GetString(0);
                    s.TotalShipments = r.GetInt32(1);
                    sc.Add(s);
                }
                return sc;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il conteggio delle spedizioni in attesa: {ex.Message}");
                throw;
            }
        }
    }
}
