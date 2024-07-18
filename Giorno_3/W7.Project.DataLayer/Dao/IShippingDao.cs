using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface IShippingDao
    {
        ShippingEntity Save(ShippingEntity shipping);
        ShippingEntity Get(int id);
        IEnumerable<ShippingEntity> GetAllByDate(DateOnly from, DateOnly to);
        IEnumerable<ShippingEntity> GetAllByStatus(ShippingStatus status);
        IEnumerable<ShippingEntity> GetAllByCity(string city);
        IEnumerable<ShippingEntity> GetAllByCustomer(string customerCode, string shippingNumber);
    }
}
