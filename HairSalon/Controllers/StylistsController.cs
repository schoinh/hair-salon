using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private readonly HairSalonContext _db;

        public StylistsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists
                .OrderBy(stylists => stylists.Name)
                .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Stylist thisStylist = _db.Stylists
                .FirstOrDefault(stylists => stylists.StylistId == id);
            ViewBag.Clients = _db.Clients
                .Where(clients => clients.StylistId == id)
                .OrderBy(clients => clients.Name)
                .ToList();
            ViewBag.Appointments = _db.Appointments
                .Where(appts => appts.StylistId == id)
                .OrderBy(appts => appts.Date)
                .ToList();
            return View(thisStylist);
        }

        public ActionResult Edit(int id)
        {
            Stylist thisStylist = _db.Stylists
                .FirstOrDefault(stylists => stylists.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Details", new { id = stylist.StylistId });
        }

        public ActionResult Delete(int id)
        {
            Stylist thisStylist = _db.Stylists
                .FirstOrDefault(stylists => stylists.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Stylist thisStylist = _db.Stylists
                .FirstOrDefault(stylists => stylists.StylistId == id);
            _db.Stylists.Remove(thisStylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}