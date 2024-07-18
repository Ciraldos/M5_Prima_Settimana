using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer.SqlServer
{
    public class UserDao : BaseDao, IUserDao
    {
        private const string INSERT_USER = "INSERT INTO Users(Username, Password) OUTPUT INSERTED.Id VALUES(@username, @password)";
        private const string DELETE_USER = "DELETE FROM Users WHERE Id = @userId";
        private const string SELECT_USER_BY_ID = "SELECT Id, Username, Password FROM Users WHERE Id = @userId";
        private const string SELECT_USER_BY_USERNAME = "SELECT Id, Username, Password FROM Users WHERE Username = @username";
        private const string SELECT_ALL_USERS = "SELECT Id, Username, Password FROM Users";
        private const string LOGIN_USER = "SELECT Id, Username, Password FROM Users WHERE Username = @username AND Password = @password";
        private const string UPDATE_USER = "UPDATE Users SET Password = @password WHERE Id = @userId";
        public UserDao(IConfiguration configuration, ILogger<UserDao> logger) : base(configuration, logger) { }

        public UserEntity Create(UserEntity user) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT_USER, conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                user.Id = (int)cmd.ExecuteScalar();
                return user;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception creating user");
                throw; // rilancia l'eccezione in maniera tale che chi abbia chiamato questo metodo decida come procedere
            }
        }

        public UserEntity Delete(int userId) {
            try {
                // recupera l'entità da cancellare
                var old = Read(userId);
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(DELETE_USER, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
                // restituisce l'entità che ho recuperato prima di cancellarla
                return old;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception deleting user with id = {}", userId);
                throw;
            }
        }

        public UserEntity Read(int userId) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_USER_BY_ID, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return new UserEntity {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                throw new Exception("User not found");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading user with id = {}", userId);
                throw;
            }
        }

        public List<UserEntity> ReadAll() {
            var result = new List<UserEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_ALL_USERS, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                    result.Add(new UserEntity {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    });
                return result;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading all users");
                throw;
            }
        }

        public UserEntity ReadByUsername(string username) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_USER_BY_USERNAME, conn);
                cmd.Parameters.AddWithValue("@username", username);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return new UserEntity {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                throw new Exception("User not found");
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception reading user with username = {}", username);
                throw;
            }
        }

        public UserEntity Update(int userId, UserEntity user) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(UPDATE_USER, conn);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@userId", userId);
                return Read(userId);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception updating user with id = {}", userId);
                throw;
            }
        }

        public UserEntity? Login(string username, string password) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(LOGIN_USER, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                    return new UserEntity {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                return null;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception logging in user with credentials = ({}, {})", username, password);
                throw;
            }
        }
    }
}
