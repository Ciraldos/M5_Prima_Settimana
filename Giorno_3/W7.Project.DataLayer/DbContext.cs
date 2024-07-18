using W7.Project.DataLayer.Dao;

namespace W7.Project.DataLayer
{
    /// <summary>
    /// Gestione dei DAO.
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// DAO per la gestione degli ordini.
        /// </summary>
        public IShippingDao ShippingDao { get; set; }
        /// <summary>
        /// DAO per la gestione dei clienti.
        /// </summary>
        public ICustomerDao CustomerDao { get; set; }
        /// <summary>
        /// DAO Per la gestione dello stato delle spedizioni.
        /// </summary>
        public IShippingStatusDao ShippingStatusDao { get; set; }

        public DbContext(IShippingDao shippingDao,
            ICustomerDao customerDao,
            IShippingStatusDao shippingStatusDao) {
            ShippingDao = shippingDao;
            CustomerDao = customerDao;
            ShippingStatusDao = shippingStatusDao;
        }
    }
}
