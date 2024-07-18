using Microsoft.Extensions.DependencyInjection;
using W7.Project.DataLayer.Dao;
using W7.Project.DataLayer.SqlServer.Dao;

namespace W7.Project.DataLayer.SqlServer
{
    public static class Helpers
    {
        public static IServiceCollection RegisterDAOs(this IServiceCollection services) =>
            services
                .AddScoped<ICustomerDao, CustomerDao>()
                .AddScoped<IShippingDao, ShippingDao>()
                .AddScoped<IShippingStatusDao, ShippingStatusDao>()
            ;
    }
}
