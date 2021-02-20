using HospitalSystem.Data.Data;
using HospitalSystem.Entities.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Web.Controllers
{
    public class AppointmentController : Controller
    {
        ApplicationDbContext _db;

        public AppointmentController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var app = _db.Appointments.Include("Patient").Include("Doctor").Include("Departman").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 20);
                return View(app);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Doctors = _db.Doctors.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.NameSurname).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Appointments.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Doctors = _db.Doctors.Where(i => i.IsConfirm == true && i.IsDeleted == false).OrderBy(i => i.NameSurname).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db = new ApplicationDbContext())
            {
                var editAppointment = _db.Appointments.Where(i => i.Id == id).FirstOrDefault();
                if (editAppointment != null)
                {
                    return View(editAppointment);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Appointments.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteAppointment = _db.Appointments.Find(id);
                if (deleteAppointment != null)
                {
                    _db.Appointments.Remove(deleteAppointment);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}