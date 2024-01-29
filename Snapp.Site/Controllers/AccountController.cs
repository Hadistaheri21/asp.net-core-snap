using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snapp.DataAccessLayer.Entities;
using Snapp.Core.Interfaces;
using Snapp.Core.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace Snapp.Site.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _account;

        public AccountController(IAccountService account)
        {
            _account = account;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModle)
        {
            if (ModelState.IsValid)
            {
                User user = await _account.RegisterUser(viewModle);

                if (user != null)
                {
                    return RedirectToAction(nameof(Active));
                }
            }
            return View(viewModle);
        }


        public IActionResult Driver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Driver(RegisterViewModel viewModle)
        {
            if (ModelState.IsValid)
            {
                User user = await _account.RegisterDriver(viewModle);

                if (user != null)
                {
                    return RedirectToAction(nameof(Active));
                }
            }
            return View(viewModle);
        }
        public IActionResult Active()
        {
            ViewBag.IsError = false;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Active(ActiveViewModle viewModle)
        {
            if (ModelState.IsValid)
            {
                User user = await _account.ActiveUser(viewModle);

                if (user != null)
                {
                    ViewBag.IsError = false;

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    return RedirectToAction("Index", "DriverPanel");
                }
            }

            ViewBag.IsError = true;

            return View(viewModle);
        }
    }
}
