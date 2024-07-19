using Esercitazione_19_07.Models;
using Esercitazione_19_07.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercitazione_19_07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnagraficaService _anagraficaService;
        private readonly IViolazioneService _violazioneService;
        private readonly IVerbaleService _verbaleService;

        public HomeController(ILogger<HomeController> logger, IAnagraficaService anagraficaService, IViolazioneService violazioneService, IVerbaleService verbaleService)
        {
            _logger = logger;
            _anagraficaService = anagraficaService;
            _violazioneService = violazioneService;
            _verbaleService = verbaleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNewAnagrafica()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewAnagrafica(Anagrafica anagrafica)
        {
            _anagraficaService.CreateAnagrafica(anagrafica);
            return RedirectToAction("Index");
        }

        public IActionResult GetAllViolazioni()
        {
            var violazioni = _violazioneService.GetAllViolazioni();
            return View(violazioni);
        }

        public IActionResult CreateVerbale()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateVerbale(Verbale verbale)
        {
            _verbaleService.CreateVerbale(verbale);
            return RedirectToAction("Index");
        }

        public IActionResult GetVerbaliPerTrasgressore()
        {
            var verbali = _verbaleService.GetVerbaliByTrasgressore();
            return View(verbali);
        }

        public IActionResult GetPuntiPerTrasgressore()
        {
            var verbali = _verbaleService.GetPuntiByTrasgressore();
            return View(verbali);
        }

        public IActionResult GetViolazioniSuperioriDieci()
        {
            var violazioni = _verbaleService.GetViolazioniSuperioriDieciPunti();
            return View(violazioni);
        }

        public IActionResult GetViolazioniSuperioriEuro()
        {
            var violazioni = _verbaleService.GetViolazioniSuperioriEuro();
            return View(violazioni);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
