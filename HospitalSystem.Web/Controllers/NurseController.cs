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
    public class NurseController : Controller
    {
        ApplicationDbContext _db;

        public NurseController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var nurseList = _db.Nurses.Include("Gender").Include("NurseInformation").Include("NurseDegree").Include("Departman").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.Hiredate).ToPagedList(page, 25);
                return View(nurseList);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Nurses.Find(id));
        }

        public ActionResult NurseInfo(int id)
        {
            var information = _db.Nurses.Where(i => i.NurseInformationId == id).FirstOrDefault();
            return View(information);
        }

        public ActionResult NurseDetail(int id)
        {
            var detail = _db.Nurses.Where(i => i.NurseDegreeId == id).FirstOrDefault();
            return View(detail);
        }

        public ActionResult Create()
        {
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nurse model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/nurse/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Nurses.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db = new ApplicationDbContext())
            {
                var editNurse = _db.Nurses.Where(i => i.Id == id).FirstOrDefault();
                if (editNurse != null)
                {
                    return View(editNurse);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nurse model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/nurse/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Nurses.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteNurse = _db.Nurses.Find(id);
                if (deleteNurse != null)
                {
                    _db.Nurses.Remove(deleteNurse);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}