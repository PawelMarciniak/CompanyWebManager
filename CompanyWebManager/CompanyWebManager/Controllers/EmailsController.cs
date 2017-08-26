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

        public async Task<IActionResult> Index()
        {
            return RedirectToAction("ReceiveEmails");
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, HttpGet]
        public async Task<IActionResult> SaveEmail(int id)
        {
            int ownerId = HttpContext.Session.GetObjectFromJson<int>("ownerID");
            Email msg = HttpContext.Session.GetItemOfSessionList<Email>(string.Format("ReceivedEmails-{0}", ownerId), id);
            msg.OwnerID = ownerId;
            msg.Saved = true;
            _context.Add(msg);
            await _context.SaveChangesAsync();

            es.SetEmailAsRead(msg.Uid);
            HttpContext.Session.RemoveFromSessionList<Email>(string.Format("ReceivedEmails-{0}", ownerId), id);
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
                email = HttpContext.Session.GetItemOfSessionList<Email>(string.Format("ReceivedEmails-{0}", HttpContext.Session.GetObjectFromJson<int>("ownerID")), id);
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
            List<Email> newEmails =  new List<Email>();
            if (string.IsNullOrEmpty(login))
            {
                return View("Index", newEmails);
            }
            //if (!string.IsNullOrEmpty(login))
            //{
            //    StoreData(login, pass);
            //}

            int ownerId = HttpContext.Session.GetObjectFromJson<int>("ownerID");
            newEmails = await es.ReceiveEmails(login, pass);
            HttpContext.Session.SetObjectAsJson(string.Format("ReceivedEmails-{0}", ownerId), newEmails);
            List<Email> emails = await _context.Emails.Where(s => s.OwnerID == ownerId).ToListAsync();

            emails.AddRange(newEmails);

            return View("Index", emails);

        }

        //public void StoreData(string email, string pass)
        //{
        //    HttpContext.Session.SetObjectAsJson("email", email);
        //    HttpContext.Session.SetObjectAsJson("pass", pass);
        //}
    }
}
