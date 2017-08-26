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
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
                var clients = _context.Clients.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));

                return View(MapClientsListToView(clients));
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

            return View(MapClientToView(client));
        }

        public IActionResult Create()
        {
            PrepareVoivodeshipsAndCountires();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,ClientEmail,Street,Town,PostalCode,Voivodeship,Country,ownerID")] ClientsViewModel client)
        {
            if (ModelState.IsValid)
            {
                client.ownerID = HttpContext.Session.GetObjectFromJson<int>("ownerID");
                _context.Add(MapViewToClient(client));
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

            PrepareVoivodeshipsAndCountires();
            return View(MapClientToView(client));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,ClientEmail,Street,Town,PostalCode,Voivodeship,Country, ownerID")] ClientsViewModel client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MapViewToClient(client));
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

            return View(MapClientToView(client));
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

        #region Helpers

        public Client MapViewToClient(ClientsViewModel clientsViewModel)
        {
            Client client = new Client
            {
                ID = clientsViewModel.ID,
                FirstName = clientsViewModel.FirstName,
                LastName = clientsViewModel.LastName,
                ClientEmail = clientsViewModel.ClientEmail,
                Street = clientsViewModel.Street,
                Town = clientsViewModel.Town,
                PostalCode = clientsViewModel.PostalCode,
                Voivodeship = clientsViewModel.Voivodeship,
                Country = clientsViewModel.Country,
                ownerID = clientsViewModel.ownerID
            };

            return client;
        }

        public ClientsViewModel MapClientToView(Client client)
        {
            ClientsViewModel vModel = new ClientsViewModel
            {
                ID = client.ID,
                FirstName = client.FirstName,
                LastName = client.LastName,
                ClientEmail = client.ClientEmail,
                Street = client.Street,
                Town = client.Town,
                PostalCode = client.PostalCode,
                Voivodeship = client.Voivodeship,
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == client.Voivodeship).Select(v => v.Name).First(),
                Country = client.Country,
                CountryName = _context.Countries.Where(v => v.ID == client.Country).Select(v => v.Name).First(),
                ownerID = client.ownerID
            };

            return vModel;
        }

        public ClientsListViewModel MapClientsListToView(IQueryable<Client> clients)
        {
            ClientsListViewModel vModel = new ClientsListViewModel();

            vModel.Clients = clients.Select(s => new ClientsViewModel()
            {
                ID = s.ID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                ClientEmail = s.ClientEmail,
                Street = s.Street,
                Town = s.Town,
                PostalCode = s.PostalCode,
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == s.Voivodeship).Select(v => v.Name).First(),
                CountryName = _context.Countries.Where(v => v.ID == s.Country).Select(v => v.Name).First(),
                ownerID = s.ownerID
            }).ToList();

            return vModel;
        }

        public void PrepareVoivodeshipsAndCountires()
        {
            List<Voivodeship> voivodeships = new List<Voivodeship>();

            voivodeships = _context.Voivodeships.ToList();
            voivodeships.Insert(0, new Voivodeship { ID = 0, Name = "Select" });
            ViewBag.Voivodeships = voivodeships;

            List<Country> countries = new List<Country>();

            countries = _context.Countries.ToList();
            countries.Insert(0, new Country { ID = 0, Name = "Select" });
            ViewBag.Countries = countries;
        }

        #endregion
    }
}
