﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulerApp.Client.Models;
using SchedulerApp.Domain;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace SchedulerApp.Client.Controllers
{
    public class AccountController : Controller
    {
        private SchedulerService service = new SchedulerService();

        public IActionResult Login()
        {
            ViewBag.Message = "Please enter Username and Password";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            Member member = service.AuthenticateUser(username, password);
            if (member != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, member.Username),
                    new Claim(ClaimTypes.Role, member.RoleName),
                    new Claim("UserId", member.Id.ToString()),
                    new Claim("FullName", member.FirstName + " " + member.LastName),
                    new Claim("FullNameReversed", member.LastName + ", " + member.FirstName)
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "password");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid Usename and/or Password";

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}