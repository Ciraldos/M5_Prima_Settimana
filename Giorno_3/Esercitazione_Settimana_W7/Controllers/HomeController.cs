using Esercitazione_Settimana_W7.Models;
using Esercitazione_Settimana_W7.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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

        [Authorize]
        public IActionResult SendEmail()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SendEmail(EmailModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string smtpServer = "smtp.gmail.com";
                    int smtpPort = 587;
                    string smtpUsername = "andreaciraldo2@gmail.com";
                    string smtpPassword = "Curiosone :)))))))";

                    using (var client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        client.EnableSsl = true;

                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress(smtpUsername),
                            Subject = model.Subject,
                            Body = model.Message,
                            IsBodyHtml = true
                        };
                        mailMessage.To.Add(model.ToEmail);
                        client.Send(mailMessage);
                        ViewBag.Message = "Email inviata con successo";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Errore nell'invio dell'email: {ex.Message}";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
