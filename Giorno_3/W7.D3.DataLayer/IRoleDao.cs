using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    public interface IRoleDao
    {
        RoleEntity Create(RoleEntity role);
        RoleEntity Read(int roleId);
        RoleEntity Update(int roleId, RoleEntity role);
        RoleEntity Delete(int roleId);

        RoleEntity Read(string roleName);
        List<RoleEntity> ReadAll();
    }
}
