using Microsoft.Extensions.DependencyInjection;

namespace W7.Project.DataLayer
{
    public static class Helpers
    {
        /// <summary>
        /// Registrazione del servizio di DbContext.
        /// </summary>
        public static IServiceCollection AddDbContext(this IServiceCollection services) =>
            services.AddScoped<DbContext>();
    }
}
