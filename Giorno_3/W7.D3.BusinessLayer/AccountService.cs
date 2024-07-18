using W7.D3.BusinessLayer.Data;
using W7.D3.DataLayer;

namespace W7.D3.BusinessLayer
{
    public class AccountService : IAccountService
    {
        private readonly DbContext dbContext;

        public AccountService(DbContext dbContext) {
            this.dbContext = dbContext;
        }
        public bool AddUserToRole(string username, string roleName) {
            throw new NotImplementedException();
        }

        public List<string> GetAllRoles() {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAllUsers() {
            throw new NotImplementedException();
        }

        public UserDto GetByUsername(string username) {
            throw new NotImplementedException();
        }

        public List<string> GetUserRoles(string username) {
            throw new NotImplementedException();
        }

        public UserDto? Login(string username, string password) {
            var u = dbContext.Users.Login(username, password);
            if (u != null)
                return new UserDto { Id = u.Id, Password = password, Username = username };
            return null;
        }

        public UserDto Register(UserDto user) {
            var u = dbContext.Users.Create(
                new DataLayer.Data.UserEntity {
                    Password = user.Password,
                    Username = user.Username
                });
            return new UserDto { Id = u.Id, Password = u.Password, Username = u.Username };
        }

        public bool RemoveUserFromRole(string username, string roleName) {
            throw new NotImplementedException();
        }
    }
}
