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
    public class EmployeeController : Controller
    {
        ApplicationDbContext _db;

        public EmployeeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employee = _db.Employees.Include("EmployeeInformation").Include("Title").Include("Gender").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(employee);
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_db.Employees.Find(id));
        }

        public ActionResult Create()
        {
            ViewBag.Titles = _db.Titles.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/employee/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Employees.Add(model);
            _db.Entry(model).State = EntityState.Added;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Titles = _db.Titles.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db=new ApplicationDbContext())
            {
                var editEmployee = _db.Employees.Where(i => i.Id == id).FirstOrDefault();
                if (editEmployee!=null)
                {
                    return View(editEmployee);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                image.SaveAs(Server.MapPath("~/img/employee/" + image.FileName));
                model.Photo = image.FileName;
            }
            _db.Employees.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteEmployee = _db.Employees.Find(id);
                if (deleteEmployee!=null)
                {
                    _db.Employees.Remove(deleteEmployee);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}