using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.Dao
{
    public interface IShippingStatusDao
    {
        ShippingStatusEntity Save(ShippingStatusEntity shippingStatus);
        IEnumerable<IShippingStatusDao> GetAllByShipping(long shippingId);
    }
}
