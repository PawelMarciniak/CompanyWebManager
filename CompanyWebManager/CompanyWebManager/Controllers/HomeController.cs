using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CompanyWebManager.Models;
using System.Security.Principal;
using CompanyWebManager.Helpers;


namespace CompanyWebManager.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index( string action)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;            

            if (isAuthenticated)
            {
                return RedirectToAction("Index", "Emails", new { area = "" });
            }
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
