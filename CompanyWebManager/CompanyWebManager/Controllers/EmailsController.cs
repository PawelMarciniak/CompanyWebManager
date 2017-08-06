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

namespace CompanyWebManager.Controllers
{
    public class EmailsController : Controller
    {
        private readonly ApplicationDb _context;
        private EmailHelper es = new EmailHelper();

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
        
        // GET: Emails/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, HttpGet]
        public async Task<IActionResult> SaveEmail(int id)
        {
            Email msg = HttpContext.Session.GetItemOfSessionList<Email>("ReceivedEmails", id);
            msg.OwnerID = 1;
            msg.Saved = true;
            _context.Add(msg);
            await _context.SaveChangesAsync();

            es.SetEmailAsRead(msg.Uid);
            HttpContext.Session.RemoveFromSessionList<Email>("ReceivedEmails", id);
            return RedirectToAction("ReceiveEmails");
        }

        public async Task<IActionResult> OpenEmailAsync(int id, bool saved)
        {
            var email = await es.GetEmailToDisplay(id, saved, _context, HttpContext.Session);

            if (email == null)
            {
                return NotFound();
            }

            return View("DisplayEmail", email);
        }

        public async Task<IActionResult> Delete(int id, bool saved)
        {
            Email email;

            if (saved)
            {
                email = await _context.Emails.SingleOrDefaultAsync(m => m.ID == id);
                _context.Emails.Remove(email);
                await _context.SaveChangesAsync();
            }
            else
            {
                email = HttpContext.Session.GetItemOfSessionList<Email>("ReceivedEmails", id);
                es.DeteleEmail(email.Uid);
            }

            return RedirectToAction("ReceiveEmails");
        }

        [HttpPost]
        public async Task<IActionResult> SendEmails(Email email, string login, string pass)
        {
            await es.Send(email, login, pass);
            return RedirectToAction("ReceiveEmails");

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

            HttpContext.Session.SetObjectAsJson("email", email);
            HttpContext.Session.SetObjectAsJson("pass", pass);

            //var key = Guid.NewGuid().ToString().Replace("-", "");

            //var encrMail = EncryptHelper.EncryptString(email, key);
            //var encrPass = EncryptHelper.EncryptString(pass, key);

            //HttpContext.Session.SetObjectAsJson("key", key);
            //HttpContext.Session.SetObjectAsJson("email", encrMail);
            //HttpContext.Session.SetObjectAsJson("pass", encrPass);
            //var tmpEmail = HttpContext.Session.GetObjectFromJson<byte[]>("email");

            //var tst = Convert.FromBase64String(tmpEmail);

            //var testEmail = EncryptHelper.DecryptString(Convert.FromBase64String(tmpEmail), key);
        }
    }
}
