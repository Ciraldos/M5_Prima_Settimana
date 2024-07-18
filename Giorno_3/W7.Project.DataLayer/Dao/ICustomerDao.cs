using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface ICustomerDao
    {
        CustomerEntity Save(CustomerEntity customer);
        CustomerEntity GetById(long id);
        IEnumerable<CustomerEntity> GetAll();
    }
}
