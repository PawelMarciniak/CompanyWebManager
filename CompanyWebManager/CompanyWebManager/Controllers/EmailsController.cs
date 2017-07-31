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
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Utilities.Encoders;

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
            return RedirectToAction("ReceiveEmails");
            // return View(await _context.Emails.ToListAsync());
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
        public async Task<IActionResult> Save([Bind("ID,Receiver,CarbonCopy,BlindCarbonCopy,Subject,Message,ReceivedTime")] Email email)
        {
                _context.Add(email);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReceiveEmails");
        }

        [HttpPost]
        public bool SaveEmail(int rowNum)
        {
            Email msg = HttpContext.Session.GetItemOfSessionList<Email>("ReceivedEmails", rowNum);
            _context.Add(msg);
            _context.SaveChangesAsync();
            return true;
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
            if (!string.IsNullOrEmpty(login))
            {
                StoreData(login, pass);
            }
            
            List<Email> newEmails = await es.ReceiveEmails(login, pass);
            HttpContext.Session.SetObjectAsJson("ReceivedEmails", newEmails);
           // SessionContext["ReceivedEmails"] = newEmails;
            List<Email> emails = await _context.Emails.ToListAsync();


            List<Email> emailsTmp = HttpContext.Session.GetObjectFromJson<List<Email>>("ReceivedEmails");

            Email msg = HttpContext.Session.GetItemOfSessionList<Email>("ReceivedEmails", 0);

            emails.AddRange(newEmails);

            return View("Index", emails);

        }

        public void StoreData(string email, string pass)
        {
            var key = EncryptHelper.GenerateKey();

            var encrMail = EncryptHelper.EncryptString(email, key);
            var encrPass = EncryptHelper.EncryptString(pass, key);

            HttpContext.Session.SetObjectAsJson("key", key);
            HttpContext.Session.SetObjectAsJson("email", encrMail);
            HttpContext.Session.SetObjectAsJson("pass", encrPass);
            var tmpEmail = HttpContext.Session.GetObjectFromJson<string>("email");

            var testEmail = EncryptHelper.DecryptString(tmpEmail, key);
        }
    }
}
