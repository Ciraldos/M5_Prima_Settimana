using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer.SqlServer
{
    public class UserRoleDao : BaseDao, IUserRoleDao
    {
        public UserRoleDao(IConfiguration configuration, ILogger<UserDao> logger) : base(configuration, logger) { }

        public UserRoleEntity Create(UserRoleEntity userRoleEntity) {
            throw new NotImplementedException();
        }

        public UserRoleEntity Delete(int userId, int roleId) {
            throw new NotImplementedException();
        }

        public List<UserRoleEntity> GetAllByUserId(int userId) {
            throw new NotImplementedException();
        }
    }
}
