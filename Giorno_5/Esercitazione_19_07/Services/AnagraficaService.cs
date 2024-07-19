using Esercitazione_19_07.Models;
using System.Data.SqlClient;

namespace Esercitazione_19_07.Services
{
    public class AnagraficaService : IAnagraficaService
    {
        private string connectionstring;
        private const string CREATE_ANAGRAFICA = "INSERT INTO Anagrafica" +
            "(Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc)" +
            "VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @Cod_Fisc)";

        public AnagraficaService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }

        public Anagrafica CreateAnagrafica(Anagrafica anagrafica)
        {
            try
            {
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(CREATE_ANAGRAFICA, conn);
                cmd.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                cmd.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                cmd.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                cmd.Parameters.AddWithValue("@Cod_Fisc", anagrafica.Cod_Fisc);
                var Id = Convert.ToInt32(cmd.ExecuteScalar());
                anagrafica.IdAnagrafica = Id;
                return anagrafica;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Anagrafica: " + ex.Message);
            }
        }
    }
}
