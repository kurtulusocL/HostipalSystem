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
    public class RoomController : Controller
    {
        ApplicationDbContext _db;

        public RoomController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var room = _db.Rooms.Include("Floor").Where(i => i.IsDeleted == false).OrderBy(i => i.Floor.Rooms.Count()).ToPagedList(page, 20);
                return View(room);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Floors = _db.Floors.Where(i => i.IsDeleted == false).OrderBy(i => i.FloorNumber).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Rooms.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Floors = _db.Floors.Where(i => i.IsDeleted == false).OrderBy(i => i.FloorNumber).ToList();
            using (_db = new ApplicationDbContext())
            {
                var editRoom = _db.Rooms.Where(i => i.Id == id).FirstOrDefault();
                if (editRoom!=null)
                {
                    return View(editRoom);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Rooms.Attach(model);
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
                var deleteRoom = _db.Rooms.Find(id);
                if (deleteRoom!=null)
                {
                    _db.Rooms.Remove(deleteRoom);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}