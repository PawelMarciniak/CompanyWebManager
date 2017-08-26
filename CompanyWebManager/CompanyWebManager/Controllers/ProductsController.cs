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

                return View(MapProductsListToView(products));
            }
            return RedirectToAction("Login", "Account", new { area = "" });
           
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(MapProductToView(product));
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
                _context.Add(MapViewToProduct(product));
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(MapProductToView(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,NetPrice,GrossPrice")] ProductsViewModel product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MapViewToProduct(product));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
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
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(MapProductToView(product));
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

        public Product MapViewToProduct(ProductsViewModel productsViewModel)
        {
            Product product = new Product
            {
                ID = productsViewModel.ID,
                Name = productsViewModel.Name,
                Description = productsViewModel.Description,
                NetPrice = productsViewModel.NetPrice,
                GrossPrice = productsViewModel.GrossPrice,
                Quantity = productsViewModel.Quantity,
                CompanyID = productsViewModel.CompanyID,
                ownerID = productsViewModel.ownerID
            };

            return product;
        }

        public ProductsViewModel MapProductToView(Product product)
        {
            ProductsViewModel vModel = new ProductsViewModel
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                NetPrice = product.NetPrice,
                GrossPrice = product.GrossPrice,
                Quantity = product.Quantity,
                CompanyID = product.CompanyID,
                ownerID = product.ownerID
            };

            return vModel;
        }

        public ProductsListViewModel MapProductsListToView(IQueryable<Product> products)
        {
            ProductsListViewModel vModel = new ProductsListViewModel();

            vModel.Products = products.Select(p => new ProductsViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                NetPrice = p.NetPrice,
                GrossPrice = p.GrossPrice,
                Quantity = p.Quantity,
                CompanyID = p.CompanyID,
                ownerID = p.ownerID
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
