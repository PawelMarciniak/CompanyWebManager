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
using CompanyWebManager.Models.Mappers;


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

                return View(CompanyMapper.MapCompaniesListToView(companies, _context));

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

            return View(CompanyMapper.MapCompanyToView(company, _context));
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
                _context.Add(CompanyMapper.MapViewToCompany(company));
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
            return View(CompanyMapper.MapCompanyToView(company, _context));
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
                    _context.Update(CompanyMapper.MapCompanyToView(company, _context));
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

            return View(CompanyMapper.MapCompanyToView(company, _context));
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
