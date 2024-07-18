using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using W7.Project.DataLayer.Dao;
using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.SqlServer.Dao
{
    public class UserDao : DaoBase, IUserDao
    {
        public UserDao(IConfiguration configuration, ILogger<CustomerDao> logger) : base(configuration, logger) {
        }

        public UserEntity Get(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll() {
            throw new NotImplementedException();
        }

        public UserEntity Save(UserEntity user) {
            throw new NotImplementedException();
        }
    }
}
