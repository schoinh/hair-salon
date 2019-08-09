using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public ActionResult Index()
        {
            List<Appointment> model = _db.Appointments.Include(appointments => appointments.Stylist).Include(appointments => appointments.Client).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
            ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
            return View(thisAppointment);
        }

        public ActionResult Edit(int id)
        {
            var thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
            ViewBag.AppointmentId = new SelectList(_db.Appointments, "AppointmentId", "Name");
            return View(thisAppointment);
        }

        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            _db.Entry(appointment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
            return View(thisAppointment);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisAppointment = _db.Appointments.FirstOrDefault(appointments => appointments.AppointmentId == id);
            _db.Appointments.Remove(thisAppointment);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}