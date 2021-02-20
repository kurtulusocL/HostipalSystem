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
    public class PatientController : Controller
    {
        ApplicationDbContext _db;

        public PatientController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int page = 1)
        {
            using (_db=new ApplicationDbContext())
            {
                var patient = _db.Patients.Include("PatientRooms").Include("Departman").Include("Appointment").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(patient);
            }
        }

        public ActionResult Detail(int id)
        {
            var information = _db.Patients.Where(i => i.PatientInformationId == id).FirstOrDefault();
            return View(information);
        }

        public ActionResult CreatePatientRoom(int? id)
        {
            Session["patientID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePatientRoom(PatientRoom model)
        {
            if (ModelState.IsValid)
            {
                model.PatientId = Convert.ToInt32(Session["patientID"]);
                using (_db=new ApplicationDbContext())
                {
                    _db.PatientRooms.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index","PatientRoom");
        }

        public ActionResult EditPatientRoom(int id)
        {
            Session["patientID"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatientRoom(PatientRoom model)
        {
            if (ModelState.IsValid)
            {
                model.PatientId = Convert.ToInt32(Session["patientID"]);
                using (_db = new ApplicationDbContext())
                {
                    _db.PatientRooms.Attach(model);
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "PatientRoom");
        }

        public ActionResult Create()
        {
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient model)
        {
            if (ModelState.IsValid)
            {
                using (_db=new ApplicationDbContext())
                {
                    _db.Patients.Add(model);
                    _db.Entry(model).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Genders = _db.Genders.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            ViewBag.Departmans = _db.Departmans.Where(i => i.IsDeleted == false).OrderBy(i => i.Name).ToList();
            using (_db=new ApplicationDbContext())
            {
                var editPatient = _db.Patients.Where(i => i.Id == id).FirstOrDefault();
                if (editPatient!=null)
                {
                    return View(editPatient);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient model)
        {
            if (ModelState.IsValid)
            {
                using (_db = new ApplicationDbContext())
                {
                    _db.Patients.Attach(model);
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
                var deletePatient = _db.Patients.Find(id);
                if (deletePatient!=null)
                {
                    _db.Patients.Remove(deletePatient);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}