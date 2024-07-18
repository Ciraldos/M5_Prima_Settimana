using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface IRoleDao
    {
        RoleEntity Save(string name);
        RoleEntity Get(string name);
        IEnumerable<RoleEntity> GetAll();
    }
}
