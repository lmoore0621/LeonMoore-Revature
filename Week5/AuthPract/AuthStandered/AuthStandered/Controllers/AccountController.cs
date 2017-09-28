using AuthStandered.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AuthStandered.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private static Dictionary<string, ClaimsIdentity> _UserStore = new Dictionary<string, ClaimsIdentity>();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View(new UserProfile());
        }

        [AllowAnonymous]
        [Authorize]
        public ActionResult Error()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserProfile p)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.Name, ClaimValueTypes.Email),
                    new Claim(ClaimTypes.Role, p.Role, ClaimValueTypes.String),
                    new Claim(ClaimTypes.Email, p.Email, ClaimValueTypes.Email),
                    new Claim("username", p.Username),
                    new Claim("username", p.Password)
                };

                var id = new ClaimsIdentity(claims, "ApplicationCookie");

                _UserStore.Add(p.Email, id);
                
                return RedirectToAction("Signin");
            }

            return RedirectToAction("Register");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignIn()
        {
            return View(new UserProfile());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignIn(UserProfile p)
        {
            if (ModelState.IsValid && _UserStore.ContainsKey(p.Email))
            {
                var auth = Request.GetOwinContext().Authentication;
                var props = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                };

                auth.SignIn(props, _UserStore[p.Email]);
                return RedirectToAction("Home");
            }

            return RedirectToAction("Error");
        }

        [Authorize]
        [HttpGet]
        public ActionResult SignOut()
        {
            if (ModelState.IsValid)
            {
                var req = Request.GetOwinContext().Authentication;
                req.SignOut();

                return RedirectToAction("Home");
            }

            return RedirectToAction("Error");
        }

        
    }
}
