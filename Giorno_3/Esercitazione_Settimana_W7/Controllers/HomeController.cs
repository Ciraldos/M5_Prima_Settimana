using Esercitazione_Settimana_W7.Models;
using Esercitazione_Settimana_W7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercitazione_Settimana_W7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult RicercaSpedizione()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult RicercaSpedizione(string codice)
        {
            Spedizioni spedizione = new Spedizioni();
            if (codice.Length == 11)
            {
                spedizione = _accountService.GetSpedizioneByIva(codice);
            }
            else if (codice.Length == 16)
            {
                spedizione = _accountService.GetSpedizioneByCf(codice);
            }


            return View("DettagliSpedizione", spedizione);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
