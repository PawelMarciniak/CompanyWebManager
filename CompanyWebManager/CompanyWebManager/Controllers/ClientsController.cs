using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Helpers;
using CompanyWebManager.Models;
using CompanyWebManager.Models.ViewModels;

namespace CompanyWebManager.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDb _context;

        public ClientsController(ApplicationDb context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {

            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                ClientsListViewModel vModel = new ClientsListViewModel();
                var clients = _context.Clients.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));

                vModel.Clients = clients.Select(s => new ClientsViewModel()
                {
                    ID = s.ID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    ClientEmail = s.ClientEmail,
                    Street = s.Street,
                    Town = s.Town, 
                    PostalCode = s.PostalCode,
                    VoivodeshipName = _context.Voivodeships.Where(v => v.ID == s.Voivodeship).Select( v => v.Name).First(),
                    CountryName = _context.Countries.Where(v => v.ID == s.Country).Select(v => v.Name).First(),
                    ownerID = s.ownerID
                }).ToList();

               // var clientsContext = _context.Clients.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));
                return View(vModel);
            }
            return RedirectToAction("Login", "Account", new { area = "" });

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public IActionResult Create()
        {
            List<Voivodeship> voivodeships = new List<Voivodeship>();

            voivodeships = _context.Voivodeships.ToList();
            voivodeships.Insert(0, new Voivodeship { ID = 0, Name = "Select" });
            ViewBag.Voivodeships = voivodeships;

            List<Country> countries = new List<Country>();

            countries = _context.Countries.ToList();
            countries.Insert(0, new Country { ID = 0, Name = "Select" });
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,ClientEmail,Street,Town,PostalCode,Voivodeship,Country,ownerID")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ownerID = HttpContext.Session.GetObjectFromJson<int>("ownerID");
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,ClientEmail,Street,Town,PostalCode,Voivodeship,Country,ownerID")] Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}
