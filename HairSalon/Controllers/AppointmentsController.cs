using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HairSalonContext _db;

        public AppointmentsController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Create(int id)
        {
            ViewBag.Stylist = _db.Stylists
                .FirstOrDefault(stylists => stylists.StylistId == id);
            ViewBag.ClientId = new SelectList(_db.Clients.Where(clients => clients.StylistId == id), "ClientId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Stylists");
        }
    }
}