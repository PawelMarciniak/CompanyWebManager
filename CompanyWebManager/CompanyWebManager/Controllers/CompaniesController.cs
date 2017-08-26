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
    public class CompaniesController : Controller
    {
        private readonly ApplicationDb _context;

        public CompaniesController(ApplicationDb context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()    
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var companies = _context.Companies.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));

                return View(MapCompaniesListToView(companies));

                //return View(await _context.Companies.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID")).ToListAsync());
            }
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(MapCompanyToView(company));
        }

        public IActionResult Create()
        {
            PrepareVoivodeshipsAndCountires();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Trade,CompanyEmail,Street,Town,PostalCode,Voivodeship,Country,OwnerID")] CompaniesViewModel company)
        {
            if (ModelState.IsValid)
            {
                company.ownerID = HttpContext.Session.GetObjectFromJson<int>("ownerID");
                _context.Add(MapViewToCompany(company));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            PrepareVoivodeshipsAndCountires();
            return View(MapCompanyToView(company));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Trade,CompanyEmail,Street,Town,PostalCode,Voivodeship,Country,OwnerID")] Company company)
        {
            if (id != company.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MapCompanyToView(company));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.ID))
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
            return View(company);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .SingleOrDefaultAsync(m => m.ID == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(MapCompanyToView(company));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.SingleOrDefaultAsync(m => m.ID == id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.ID == id);
        }

        #region Helpers

        public Company MapViewToCompany(CompaniesViewModel companiesViewModel)
        {
            Company company = new Company
            {
                ID = companiesViewModel.ID,
                Name = companiesViewModel.Name,
                Trade = companiesViewModel.Trade,
                CompanyEmail = companiesViewModel.CompanyEmail,
                Street = companiesViewModel.Street,
                Town = companiesViewModel.Town,
                PostalCode = companiesViewModel.PostalCode,
                Voivodeship = companiesViewModel.Voivodeship,
                Country = companiesViewModel.Country,
                ownerID = companiesViewModel.ownerID
            };

            return company;
        }

        public CompaniesViewModel MapCompanyToView(Company company)
        {
            CompaniesViewModel vModel = new CompaniesViewModel
            {
                ID = company.ID,
                Name = company.Name,
                Trade = company.Trade,
                CompanyEmail = company.CompanyEmail,
                Street = company.Street,
                Town = company.Town,
                PostalCode = company.PostalCode,
                Voivodeship = company.Voivodeship,
                Country = company.Country,
                ownerID = company.ownerID,
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == company.Voivodeship).Select(v => v.Name).First(),
                CountryName = _context.Countries.Where(v => v.ID == company.Country).Select(v => v.Name).First()
            };

            return vModel;
        }

        public CompaniesListViewModel MapCompaniesListToView(IQueryable<Company> companies)
        {
            CompaniesListViewModel vModel = new CompaniesListViewModel();

            vModel.Companies = companies.Select(c => new CompaniesViewModel()
            {
                ID = c.ID,
                Name = c.Name,
                Trade = c.Trade,
                CompanyEmail = c.CompanyEmail,
                Street = c.Street,
                Town = c.Town,
                PostalCode = c.PostalCode,
                ownerID = c.ownerID,
                VoivodeshipName = _context.Voivodeships.Where(v => v.ID == c.Voivodeship).Select(v => v.Name).First(),
                CountryName = _context.Countries.Where(v => v.ID == c.Country).Select(v => v.Name).First()
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
