using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface IUserRoleDao
    {
        UserRoleEntity Save(string username, string roleName);
        UserRoleEntity Delete(string username, string roleName);
        IEnumerable<UserRoleEntity> GetAllByUser(string username);
        IEnumerable<UserRoleEntity> GetAllByRole(string roleName);
    }
}
