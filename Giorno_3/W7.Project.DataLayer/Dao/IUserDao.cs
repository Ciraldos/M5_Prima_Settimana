using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface IUserDao
    {
        UserEntity Save(UserEntity user);
        UserEntity Get(int id);
        IEnumerable<UserEntity> GetAll();
    }
}
