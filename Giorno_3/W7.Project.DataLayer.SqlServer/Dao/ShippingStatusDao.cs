using W7.Project.DataLayer.Dao;
using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.SqlServer.Dao
{
    public class ShippingStatusDao : IShippingStatusDao
    {
        public IEnumerable<IShippingStatusDao> GetAllByShipping(long shippingId) {
            throw new NotImplementedException();
        }

        public ShippingStatusEntity Save(ShippingStatusEntity shippingStatus) {
            throw new NotImplementedException();
        }
    }
}
