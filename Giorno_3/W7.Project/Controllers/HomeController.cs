using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using W7.Project.DataLayer;
using W7.Project.DataLayer.Entities;
using W7.Project.Models;

namespace W7.Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DbContext context) {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult Index() {
            if (!_dbContext.CustomerDao.GetAll().Any()) {
                _dbContext.CustomerDao.Save(new PersonEntity {
                    Address = "via del Deposito",
                    City = "Paperopoli",
                    FirstName = "Paperon",
                    LastName = "De' Paperoni",
                    FiscalCode = "DPPPPN70A01P000X",
                    PostalCode = "33333"
                });
            }
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
