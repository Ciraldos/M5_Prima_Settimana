using Esercitazione_M5_Prima_Settimana.Services.Models;
using System.Data.SqlClient;

namespace Esercitazione_M5_Prima_Settimana.Services
{
    public class AuthService : IAuthService
    {
        private string connectionString;

        private const string roles_command = "SELECT RoleName FROM Roles WHERE Username = @user and Password = @pass ";
        private const string command = "SELECT Id FROM Users WHERE UserId = @id";

        public AuthService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AuthDb")!;
        }

        public ApplicationUser Login(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var u = new ApplicationUser { Id = r.GetInt32(0), Password = password, Username = username };
                    r.Close();
                    using var roleCmd = new SqlCommand(roles_command, conn);
                    roleCmd.Parameters.AddWithValue("@id", u.Id);
                    using var re = roleCmd.ExecuteReader();
                    while (re.Read())
                    {
                        u.Roles.Add(r.GetString(0));
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}
