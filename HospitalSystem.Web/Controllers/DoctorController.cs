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
    public class DoctorController : Controller
    {
        ApplicationDbContext _db;

        public DoctorController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var doctor = _db.Doctors.Include("Gender").Include("Title").Include("DoctorInformation").Include("Departman").Include("DoctorDegree").Include("Floor").Include("Room").Include("Appointments").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderBy(i => i.Appointments.Count()).ToPagedList(page, 30);

                return View(doctor);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Doctors.Find(id));
        }

        public ActionResult DoctorDetail(int id)
        {
            var degree = _db.Doctors.Where(i => i.DoctorDegreeId == id).FirstOrDefault();
            return View(degree);
        }

        public ActionResult DoctorInfo(int id)
        {
            var information = _db.Doctors.Where(i => i.DoctorInformationId == id).FirstOrDefault();
            return View(information);
        }

        public ActionResult Create()
        {
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Titles = _db.Titles.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Floors = _db.Floors.Where(i => i.IsDeleted == false).OrderBy(i => i.FloorNumber).ToList();
            ViewBag.Rooms = _db.Rooms.Where(i => i.IsDeleted == false).OrderBy(i => i.RoomNumber).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/doctor/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Doctors.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Titles = _db.Titles.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Floors = _db.Floors.Where(i => i.IsDeleted == false).OrderBy(i => i.FloorNumber).ToList();
            ViewBag.Rooms = _db.Rooms.Where(i => i.IsDeleted == false).OrderBy(i => i.RoomNumber).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();

            using (_db = new ApplicationDbContext())
            {
                var editDoctor = _db.Doctors.Where(i => i.Id == id).FirstOrDefault();
                if (editDoctor != null)
                {
                    return View(editDoctor);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Doctor model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/doctor/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Doctors.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteDoctor = _db.Doctors.Find(id);
                if (deleteDoctor != null)
                {
                    _db.Doctors.Remove(deleteDoctor);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}