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

        // GET: Transactions
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
        public ActionResult Search(string name)
        {
            var routeList = _context.Product.Where(r => r.Name.Contains(name))
                .Take(5)
                .Select(r => new { id = r.ID, label = r.Name, netprice = r.NetPrice, grossprice = r.GrossPrice});
            return Json(routeList);
        }

        // GET: Transactions/Details/5
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






            //var transDesc = _context.TransactionDescription.SingleOrDefault(t => t.ID == id);

            //from s in db.Services
            //    join sa in db.ServiceAssignments on s.Id equals sa.ServiceId
            //    where sa.LocationId == 1
            //    select s

            //var productsOfTransactions = (from t in _context.Transaction
            //    join p in _context.Product on t.ProductID equals p.ID
            //    where t.TransactionDescriptionID == id
            //    select t);


            // var productsOfTransactions =
            //    _context.ProductsOfTransactions.Where(t => t.TransactionDescriptionID == id);

            //var productsOfTransactions = _context.Transaction.Join(_context.Product, p => p.ProductID, pr => pr.ID,
            //   (p, pr) => new { Transaction = p, Product = pr });

            //var productsOfTransactions = _context.Transaction.Join(_context.Product, p => p.ProductID, pr => pr.ID)
            //    .Where(tr => tr.);



            //_context.TransactionDescription
            //.Join(_context.Transaction, td => td.ID, t => t.TransactionDescriptionID,
            //    (td, t) => new {TransactionDescription = td, Transaction = t})
            //.Join(_context.Product, p => p.Transaction.ProductID, pr => pr.ID,
            //    (p, pr) => new {Transaction = p, Product = pr})
            //.Where(transdesc => transdesc.Transaction.TransactionDescription.ID == id)
            //.SelectMany(transdesc => new ProductsOfTransaction
            //{
            //    TransactionDescription = transdesc.Transaction.TransactionDescription,
            //    Transactions  = transdesc.Transaction.Transaction
            //});



            //var transaction = await _context.Transaction
            //     .SingleOrDefaultAsync(m => m.ID == id);
            // if (transaction == null)
            // {
            //     return NotFound();
            // }

            return View(vModel);
        }

        // GET: Transactions/Create
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
                    try
                    {
                        ts.SaveTransaction(transactionData, _context);
                    }
                    catch 
                    {
                      return  Json("Error");
                    }
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

        // GET: Transactions/Edit/5
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

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Transactions/Delete/5
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

        // POST: Transactions/Delete/5
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
