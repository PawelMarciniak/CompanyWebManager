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
using CompanyWebManager.Models.Mappers;

namespace CompanyWebManager.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDb _context;

        public ProductsController(ApplicationDb context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var products = _context.Product.Where(s => s.ownerID == HttpContext.Session.GetObjectFromJson<int>("ownerID"));

                return View(ProductMapper.MapProductsListToView(products));
            }
            return RedirectToAction("Login", "Account", new { area = "" });
           
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);

            return View(ProductMapper.MapProductToView(product));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,NetPrice,GrossPrice,Quantity")] ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                product.ownerID = HttpContext.Session.GetObjectFromJson<int>("ownerID");
                product.GrossPrice = product.NetPrice * 1.23M;
                _context.Add(ProductMapper.MapViewToProduct(product));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);
            return View(ProductMapper.MapProductToView(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,NetPrice,GrossPrice")] ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                 _context.Update(ProductMapper.MapViewToProduct(product));
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);

            return View(ProductMapper.MapProductToView(product));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
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
