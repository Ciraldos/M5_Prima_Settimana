using W7.Project.DataLayer.Dao;
using W7.Project.DataLayer.Entities;

namespace W7.Project.DataLayer.SqlServer.Dao
{
    public class ShippingDao : IShippingDao
    {
        public ShippingEntity Get(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShippingEntity> GetAllByCity(string city) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShippingEntity> GetAllByCustomer(string customerCode, string shippingNumber) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShippingEntity> GetAllByDate(DateOnly from, DateOnly to) {
            throw new NotImplementedException();
        }

        public IEnumerable<ShippingEntity> GetAllByStatus(ShippingStatus status) {
            throw new NotImplementedException();
        }

        public ShippingEntity Save(ShippingEntity shipping) {
            throw new NotImplementedException();
        }
    }
}
