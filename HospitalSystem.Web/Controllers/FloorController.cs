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
    public class FloorController : Controller
    {
        ApplicationDbContext _db;

        public FloorController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            using (_db=new ApplicationDbContext())
            {
                var floor = _db.Floors.Include("Rooms").Where(i => i.IsDeleted == false).OrderBy(i => i.Rooms.Count()).ToList();
                return View(floor);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Floor model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Floors.Add(model);
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
                var editFloor = _db.Floors.Where(i => i.Id == id).FirstOrDefault();
                if (editFloor!=null)
                {
                    return View(editFloor);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Floor model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Floors.Attach(model);
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
                var deleteFloor = _db.Floors.Find(id);
                if (deleteFloor!=null)
                {
                    _db.Floors.Remove(deleteFloor);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}