using Microsoft.AspNetCore.Mvc;
using W7.Project.DataLayer;

namespace W7.Project.Controllers
{
    public class CustomersController : AdminController
    {
        public CustomersController(ILogger<AdminController> logger, DbContext dbContext) : base(logger, dbContext) {
        }

        public IActionResult Index() {
            return View(dbContext.CustomerDao.GetAll());
        }

        public IActionResult RegisterCompany() {
            return View();
        }
        public IActionResult RegisterPerson() {
            return View();
        }
    }
}
