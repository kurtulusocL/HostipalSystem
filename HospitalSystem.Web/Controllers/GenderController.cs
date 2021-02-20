using HospitalSystem.Data.Data;
using HospitalSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Web.Controllers
{
    public class GenderController : Controller
    {
        ApplicationDbContext _db;

        public GenderController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            using (_db=new ApplicationDbContext())
            {
                var gender = _db.Genders.Include("Nurses").Include("Doctors").Include("Patients").Include("Employees").Where(i => i.IsDeleted == false).OrderByDescending(i => i.CreatedDate).ToList();
                return View(gender);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gender model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Genders.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var editGender = _db.Genders.Where(i => i.Id == id).FirstOrDefault();
                if (editGender!=null)
                {
                    return View(editGender);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gender model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Genders.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db=new ApplicationDbContext())
            {
                var deleteGender = _db.Genders.Find(id);
                if (deleteGender!=null)
                {
                    _db.Genders.Remove(deleteGender);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}