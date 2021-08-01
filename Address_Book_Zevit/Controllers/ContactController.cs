using Address_Book_Zevit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book_Zevit.Controllers
{
    public class ContactController : Controller
    {
        readonly ApplicationDbContext db;

        public ContactController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult ViewSingleContact(int? id)
        {
            if (id == null)
            {
                return BadRequest("Not Found");
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return BadRequest("Not Found");
            }
            return View(contact);
        }


        [HttpGet]
        public IActionResult AddContact()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            try
            {
                var cont = db.Contacts.Where(c=> c.PhoneNumber == contact.PhoneNumber);
                if (cont.Count() == 0)
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "You already have this contact!");
                }
                return View(contact);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult DeleteContact(int? id)
        {
            if (id == null)
            {
                return BadRequest("Not Found");
            }
            Contact contact = db.Contacts.Find(id);

            if (contact == null)
            {
                BadRequest("Not Found");
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteContact(Contact contact)
        {
            try
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditContact(int? id)
        {
            if (id == null)
            {
                return BadRequest("Not Found");
            }

            Contact contact = db.Contacts.Find(id);

            if (contact == null)
            {
                return BadRequest("Not Found");
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}
