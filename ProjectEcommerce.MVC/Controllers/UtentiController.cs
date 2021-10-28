using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectEcommerce.CORE.BusinessLayer;
using ProjectEcommerce.MVC.Mapping;
using ProjectEcommerce.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectEcommerce.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;
   
        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UtenteLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteLoginViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var utente = BL.GetAccount(utenteLoginViewModel.Username);
            if (utente != null && ModelState.IsValid)
            {
                if (utente.Password == utenteLoginViewModel.Password)
                {
                    //l'utente è autenticato

                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, utente.Nome),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString())
                    };
                    //durata della sessione, se voglio che dopo un ora che utente non regisce sull sito -> logout
                    var properties = new AuthenticationProperties()
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = utenteLoginViewModel.ReturnUrl,
                    };
                    //mi creo nuova identita a partire dalle claim -> sopra
                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    //se ce async ->await davanti, ci fa autenticazione e porta tutto al sito
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );

                    return Redirect("/");

                }
                else
                {
                    //utente esiste ma la password non e valida
                    ModelState.AddModelError(nameof(utenteLoginViewModel.Password), "Password errata!");
                    return View(utenteLoginViewModel);
                }
            }
            return View();
        }

        [HttpGet]    
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UtenteLoginViewModel utenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var utenteRegister = utenteViewModel.ToUtente();
                BL.InserisciNuovoUtente(utenteRegister);
                return RedirectToAction(nameof(Index));
            }
            return View(utenteViewModel);
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden() => View();
        //{
        //    return View();
        //}
    }
}
