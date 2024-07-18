using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7.D3.DataLayer.SqlServer
{
    public class BaseDao
    {
        protected readonly string connectionString;
        protected readonly ILogger<UserDao> logger;

        public BaseDao(IConfiguration configuration, ILogger<UserDao> logger) {
            this.logger = logger;
            // il ! indica che se il risultato del metodo è null
            // otteniamo un'eccezione
            connectionString = configuration.GetConnectionString("AppAuthDatabase")!;
        }
    }
}
