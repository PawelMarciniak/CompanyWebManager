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
using CompanyWebManager.Models.DataModels;
using CompanyWebManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.WebEncoders.Testing;

namespace CompanyWebManager.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDb _context;
        private TransactionHelper ts = new TransactionHelper();

        public TransactionsController(ApplicationDb context)
        {
            _context = context;    
        }

        public async Task<IActionResult> Index()
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                return View(await _context.TransactionDescription.ToListAsync());
            }
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        [HttpPost]
        [HttpGet]
        public ActionResult SearchProducts(string name)
        {
            var products = _context.Product.Where(r => r.Name.Contains(name))
                .Take(5)
                .Select(r => new { id = r.ID, label = r.Name, netprice = r.NetPrice, grossprice = r.GrossPrice});
            return Json(products);
        }

        [HttpPost]
        [HttpGet]
        public ActionResult CheckAvaiability([FromBody] ProductMaxAvaiability productInfo)
        {
            var quantity = _context.Product.Where(p => p.ID == productInfo.ProductID).Select(p => p.Quantity).First();

            ProductMaxAvaiability maxAvaiability = new ProductMaxAvaiability
            {
                Message = quantity >= productInfo.Units ? "available" : "error",
                MaxAvaiability = quantity
            };

            return Json(maxAvaiability);
        }

        public async Task<IActionResult> Details(int id)
        {

            ProductsOfTransactionsListViewModel vModel = new ProductsOfTransactionsListViewModel();

            var productsOfTransactions = _context.ProductsOfTransactions.Where(t => t.TransactionDescriptionID == id).ToList();
            vModel.ProductsOfTransactions = productsOfTransactions.Select(s => new ProductsOfTransactionsViewModel()
            {
                GrossPrice = s.GrossPrice,
                NetPrice = s.NetPrice,
                ProductName = s.ProductName,
                ProductUnits = s.ProductUnits,
                TransactionDescriptionID = s.TransactionDescriptionID,
                TransactionID = s.TransactionID,
                TransDescDate = s.TransDescDate,
                TransDescDesc = s.TransDescDesc,
                Type = s.Type,
                UnitGrossPrice = s.UnitGrossPrice,
                UnitNetPrice = s.UnitNetPrice
            }).ToList();

            return View(vModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save([FromBody]TransactionData transactionData)
        {
            if (transactionData != null)
            {
                if (ModelState.IsValid)
                {

                ts.SaveTransaction(transactionData, _context, HttpContext.Session.GetObjectFromJson<int>("ownerID"));
                    

                }
            }
            else
            {
                return Json("Error");
            }

            return Json("Success");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransactionID,Type,ProductID,ProductNetPrice,ProductGrossPrice,Date")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.SingleOrDefaultAsync(m => m.ID == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransactionID,Type,ProductID,ProductNetPrice,ProductGrossPrice,Date")] Transaction transaction)
        {
            if (id != transaction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.ID))
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
            return View(transaction);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .SingleOrDefaultAsync(m => m.ID == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.SingleOrDefaultAsync(m => m.ID == id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.ID == id);
        }
    }
}
