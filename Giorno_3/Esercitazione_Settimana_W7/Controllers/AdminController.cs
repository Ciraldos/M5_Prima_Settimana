using Esercitazione_Settimana_W7.Models;
using Esercitazione_Settimana_W7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione_Settimana_W7.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        public IActionResult Spedizioni()
        {
            IEnumerable<Spedizioni> s = new List<Spedizioni>();
            s = _adminService.GetAllShippings();
            return View(s);
        }
        public IActionResult SpedizioniToday()
        {
            IEnumerable<Spedizioni> s = new List<Spedizioni>();
            s = _adminService.GetAllShippingsToday();
            return View(s);
        }

        public IActionResult SpedizioniAwaiting()
        {
            int countAwaiting = _adminService.GetAllShippingsAwaiting();
            ViewBag.CountAwaiting = countAwaiting;
            return View();
        }

        public IActionResult SpedizioniByCity()
        {
            var sc = _adminService.GetAllShippingsByCity();
            return View(sc);
        }
    }
}
