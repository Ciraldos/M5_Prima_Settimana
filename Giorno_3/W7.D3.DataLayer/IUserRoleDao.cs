using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    public interface IUserRoleDao
    {
        UserRoleEntity Create(UserRoleEntity userRoleEntity);
        UserRoleEntity Delete(int userId, int roleId);
        List<UserRoleEntity> GetAllByUserId(int userId);
    }
}
