using Esercitazione_Settimana_W7.Models;
using Microsoft.Data.SqlClient;

namespace Esercitazione_Settimana_W7.Services
{
    public class AuthService : IAuthService
    {
        private string connectionstring;
        private const string LOGIN_COMMAND = "SELECT Id FROM Users WHERE Username = @username AND Password = @password";
        private const string ROLES_COMMAND = "SELECT RoleName FROM Roles ro JOIN UserRoles ur ON ro.Id = ur.RoleId WHERE UserId = @id";
        private const string REGISTER_COMMAND = "INSERT INTO Users (Username, Password) OUTPUT INSERTED.Id VALUES (@username, @password)";

        public AuthService(IConfiguration configuration)
        {
            connectionstring = configuration.GetConnectionString("AuthDb")!;
        }
        public Users Login(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(LOGIN_COMMAND, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    var u = new Users { Id = r.GetInt32(0), Username = username, Password = password };
                    r.Close();
                    using var roleCmd = new SqlCommand(ROLES_COMMAND, conn);
                    roleCmd.Parameters.AddWithValue("@id", u.Id);
                    using var re = roleCmd.ExecuteReader();
                    while (re.Read())
                    {
                        u.Roles.Add(re.GetString(0));
                    }
                    return u;
                }

            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public Users Register(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionstring);
                conn.Open();
                using var cmd = new SqlCommand(REGISTER_COMMAND, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                var userId = (int)cmd.ExecuteScalar();

                string assignRoleCommand = "INSERT INTO UserRoles (UserId, RoleId) VALUES (@UserId, 2)";
                using (var roleCommand = new SqlCommand(assignRoleCommand, conn))
                {
                    roleCommand.Parameters.AddWithValue("@UserId", userId);
                    roleCommand.ExecuteNonQuery();
                }


                return new Users
                {
                    Id = userId,
                    Username = username,
                    Password = password,
                    Roles = new List<string> { "user" }
                };

            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante la registrazione dell'utente: " + ex.Message);

            }
        }
    }
}
