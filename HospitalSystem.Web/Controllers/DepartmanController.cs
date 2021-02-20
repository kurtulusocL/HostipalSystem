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
    public class DepartmanController : Controller
    {
        ApplicationDbContext _db;

        public DepartmanController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var departman = _db.Departmans.Include("Patients").Include("Nurses").Include("Doctors").Include("Appointments").Where(i => i.IsDeleted == false).OrderByDescending(i => i.Appointments.Count()).ToPagedList(page, 25);
                return View(departman);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departman model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Departmans.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var editDepartman = _db.Departmans.Where(i => i.Id == id).FirstOrDefault();
                if (editDepartman != null)
                {
                    return View(editDepartman);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departman model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Departmans.Attach(model);
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
                var deleteDepartman = _db.Departmans.Find(id);
                if (deleteDepartman!=null)
                {
                    _db.Departmans.Remove(deleteDepartman);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}