using Esercitazione_19_07.Models;
using System.Data.SqlClient;

namespace Esercitazione_19_07.Services
{
    public class VerbaleService : IVerbaleService
    {
        private string connectionstring;
        private const string COMMAND_CREATE_VERBALE = "INSERT INTO Verbale" +
            "(DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, FK_Violazione, FK_Anagrafica)" +
            "VALUES (@DataViolazione, @IndirizzoViolazione, @Nominativo_Agente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @FK_Violazione, @FK_Anagrafica)";
        private const string COMMAND_VERBALI_TRASGRESSORI = "SELECT (a.Cognome + ' ' + a.Nome) AS Nome, COUNT(v.IdVerbale) AS TotaleVerbali FROM Verbale AS v JOIN Anagrafica AS a ON v.FK_Anagrafica = a.IdAnagrafica GROUP BY a.Cognome, a.Nome";
        private const string COMMAND_PUNTI_TRASGRESSORI = "SELECT (a.Cognome + ' ' + a.Nome) AS Nome, SUM(v.DecurtamentoPunti) AS TotalePuntiDecurtati FROM Verbale AS v JOIN Anagrafica AS a ON v.FK_Anagrafica = a.IdAnagrafica GROUP BY a.Cognome, a.Nome";
        private const string COMMAND_PUNTI_DIECI = "SELECT v.Importo, a.Cognome, a.Nome, v.DataViolazione, v.DecurtamentoPunti FROM Verbale AS v JOIN Anagrafica AS a ON v.FK_Anagrafica = a.IdAnagrafica WHERE v.DecurtamentoPunti > 10";
        private const string COMMAND_VERBALI_EURO = "SELECT (a.Cognome + ' ' + a.Nome) AS Nome, v.* FROM Verbale AS v JOIN Anagrafica AS a ON v.FK_Anagrafica = a.IdAnagrafica WHERE v.Importo > 100";
        public VerbaleService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }
        public Verbale CreateVerbale(Verbale verbale)
        {
            try
            {
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_CREATE_VERBALE, conn);
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@FK_Violazione", verbale.FK_Violazione);
                cmd.Parameters.AddWithValue("@FK_Anagrafica", verbale.FK_Anagrafica);
                cmd.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                var Id = Convert.ToInt32(cmd.ExecuteScalar());
                verbale.IdVerbale = Id;
                return verbale;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public IEnumerable<VerbaleTrasgressore> GetVerbaliByTrasgressore()
        {
            try
            {
                List<VerbaleTrasgressore> v = new List<VerbaleTrasgressore>();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_VERBALI_TRASGRESSORI, conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    VerbaleTrasgressore vt = new VerbaleTrasgressore();
                    vt.Trasgressore = r.GetString(0);
                    vt.TotaleVerbali = r.GetInt32(1);
                    v.Add(vt);
                }
                return v;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il conteggio dei verbali per trasgressore: {ex.Message}");
                throw;
            }
        }
        public IEnumerable<VerbaleTrasgressore> GetPuntiByTrasgressore()
        {
            try
            {
                List<VerbaleTrasgressore> v = new List<VerbaleTrasgressore>();
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_PUNTI_TRASGRESSORI, conn);
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    VerbaleTrasgressore vt = new VerbaleTrasgressore();
                    vt.Trasgressore = r.GetString(0);
                    vt.TotaleVerbali = r.GetInt32(1);
                    v.Add(vt);
                }
                return v;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante il conteggio dei verbali per trasgressore: {ex.Message}");
                throw;
            }
        }

        public List<ViolazionePuntiDieci> GetViolazioniSuperioriDieciPunti()
        {
            List<ViolazionePuntiDieci> v = new List<ViolazionePuntiDieci>();

            try
            {
                // Connessione al database
                using var conn = new SqlConnection(connectionstring);
                conn.Open();

                // Esecuzione della query SQL
                using var cmd = new SqlCommand(COMMAND_PUNTI_DIECI, conn);
                using var reader = cmd.ExecuteReader();

                // Lettura dei risultati
                while (reader.Read())
                {
                    v.Add(new ViolazionePuntiDieci
                    {
                        Importo = reader.GetDecimal(0),
                        Cognome = reader.GetString(1),
                        Nome = reader.GetString(2),
                        DataViolazione = reader.GetDateTime(3),
                        DecurtamentoPunti = reader.GetInt32(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la ricerca di verbali che superano i 10 punti: " + ex.Message);
                throw;
            }

            return v;
        }
        public List<VerbaleAnagrafico> GetViolazioniSuperioriEuro()
        {
            List<VerbaleAnagrafico> va = new List<VerbaleAnagrafico>();

            try
            {

                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(COMMAND_VERBALI_EURO, conn);
                using var reader = cmd.ExecuteReader();

                // Lettura dei risultati
                while (reader.Read())
                {
                    va.Add(new VerbaleAnagrafico
                    {
                        Nome = reader.GetString(0),
                        V = new Verbale
                        {
                            IdVerbale = reader.GetInt32(1),
                            DataViolazione = reader.GetDateTime(2),
                            IndirizzoViolazione = reader.GetString(3),
                            Nominativo_Agente = reader.GetString(4),
                            DataTrascrizioneVerbale = reader.GetDateTime(5),
                            Importo = reader.GetDecimal(6),
                            DecurtamentoPunti = reader.GetInt32(7),
                            FK_Violazione = reader.GetInt32(8),
                            FK_Anagrafica = reader.GetInt32(9)
                        }
                    }
                );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la ricerca di verbali che superano i 400 euro: " + ex.Message);
                throw;
            }
            return va;
        }
    }
}
