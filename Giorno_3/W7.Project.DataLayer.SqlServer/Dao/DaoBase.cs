using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace W7.Project.DataLayer.SqlServer.Dao
{
    public abstract class DaoBase
    {
        protected ILogger<DaoBase> logger;
        protected readonly string connectionString;

        public DaoBase(IConfiguration configuration, ILogger<CustomerDao> logger) {
            connectionString = configuration.GetConnectionString("SqlServer")!;
            this.logger = logger;
        }
    }
}
