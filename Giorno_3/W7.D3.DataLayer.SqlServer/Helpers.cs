using Microsoft.Extensions.DependencyInjection;

namespace W7.D3.DataLayer.SqlServer
{
    public static class Helpers
    {
        /// <summary>
        /// Extension method per la configurazione nella D.I. dei DAO.
        /// </summary>
        /// <param name="services">La collezione dei servizi gestiti dalla D.I.</param>
        public static IServiceCollection RegisterDAOs(this IServiceCollection services) {
            return services
                .AddScoped<IUserDao, UserDao>()
                .AddScoped<IRoleDao, RoleDao>()
                .AddScoped<IUserRoleDao, UserRoleDao>()
                ;
        }
    }
}
