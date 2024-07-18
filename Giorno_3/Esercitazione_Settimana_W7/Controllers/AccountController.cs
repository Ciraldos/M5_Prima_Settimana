using Esercitazione_Settimana_W7.Models;
using Esercitazione_Settimana_W7.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Esercitazione_Settimana_W7.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            try
            {
                var u = _authService.Login(user.Username, user.Password);
                if (u == null) return RedirectToAction("Index", "Home");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.Username)
                };

                u.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }

            catch (Exception ex)
            {
            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            try
            {
                var registeredUser = _authService.Register(user.Username, user.Password);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Login");
        }



        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
