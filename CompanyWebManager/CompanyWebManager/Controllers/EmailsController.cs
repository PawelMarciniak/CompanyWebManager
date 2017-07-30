using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyWebManager.DataContexts;
using CompanyWebManager.Models;
using CompanyWebManager.Helpers;

namespace CompanyWebManager.Controllers
{
    public class EmailsController : Controller
    {
        private readonly ApplicationDb _context;
        private EmailSender es = new EmailSender();

        public EmailsController(ApplicationDb context)
        {
            _context = context;    
        }

        // GET: Emails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emails.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Emails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Sender,Title,Message,ReceivedTime")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(email);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails.SingleOrDefaultAsync(m => m.ID == id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Sender,Title,Message,ReceivedTime")] Email email)
        {
            if (id != email.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.ID))
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
            return View(email);
        }

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _context.Emails.SingleOrDefaultAsync(m => m.ID == id);
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.ID == id);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmails(Email email, string login, string pass)
        {
            await es.Send(email, login, pass);

            return View("Index");
            
        }

        public async Task<IActionResult> ReceiveEmails(string login, string pass)
        {
            List<Email> newEmails = await es.ReceiveEmails(login, pass);

            List<Email> emails = await _context.Emails.ToListAsync();

            emails.AddRange(newEmails);

            return View("Index", emails);

        }
    }
}
