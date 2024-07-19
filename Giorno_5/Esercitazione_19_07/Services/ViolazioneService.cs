using Esercitazione_19_07.Models;
using System.Data.SqlClient;

namespace Esercitazione_19_07.Services
{
    public class ViolazioneService : IViolazioneService
    {
        private string connectionstring;
        private const string COMMAND_ALL_VIOLAZIONI = "SELECT * FROM Violazione";

        public ViolazioneService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }

        public IEnumerable<Violazione> GetAllViolazioni()
        {
            try
            {
                List<Violazione> violazioni = new List<Violazione>();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_ALL_VIOLAZIONI, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Violazione v = new Violazione();
                    {
                        v.IdViolazione = reader.GetInt32(0);
                        v.Descrizione = reader.GetString(1);
                    }
                    violazioni.Add(v);
                }
                return violazioni;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
