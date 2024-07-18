using Microsoft.AspNetCore.Mvc;
using W7.Project.DataLayer;

namespace W7.Project.Controllers
{
    public class AdminController : Controller
    {
        protected readonly ILogger<AdminController> logger;
        protected readonly DbContext dbContext;
        public AdminController(ILogger<AdminController> logger, DbContext dbContext) {
            this.logger = logger;
            this.dbContext = dbContext;
        }
    }
}
