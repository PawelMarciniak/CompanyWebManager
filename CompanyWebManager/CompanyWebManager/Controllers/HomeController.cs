using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CompanyWebManager.Models;
using System.Security.Principal;


namespace CompanyWebManager.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                return RedirectToAction("Index", "Emails", new { area = "" });
            }
            else
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
