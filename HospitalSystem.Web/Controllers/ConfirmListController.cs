using HospitalSystem.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Web.Controllers
{
    public class ConfirmListController : Controller
    {
        ApplicationDbContext _db;

        public ConfirmListController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult AppointmentConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var app = _db.Appointments.Include("Patient").Include("Doctor").Include("Departman").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(app);
            }
        }

        public ActionResult AppointmentConfirm(int id)
        {
            var confirm = _db.Appointments.Where(i => i.Id == id).FirstOrDefault();
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("AppointmentConfirmList");
        }

        public ActionResult EmployeeConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var employee = _db.Employees.Include("EmployeeInformation").Include("Title").Include("Gender").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(employee);
            }
        }

        public ActionResult EmployeeConfirm(int id)
        {
            var confirm = _db.Employees.Where(i => i.Id == id).FirstOrDefault();
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("EmployeeConfirmList");
        }

        public ActionResult NurseConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var nurse = _db.Nurses.Include("Gender").Include("NurseInformation").Include("NurseDegree").Include("Departman").Where(i => i.IsDeleted == false && i.IsConfirm == false).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(nurse);
            }
        }

        public ActionResult NurseConfirm(int id)
        {
            var confirm = _db.Nurses.Where(i => i.Id == id).FirstOrDefault();
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("NurseConfirmList");
        }

        public ActionResult DoctorConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var doctor = _db.Doctors.Include("Gender").Include("Title").Include("DoctorInformation").Include("Departman").Include("DoctorDegree").Include("Floor").Include("Room").Include("Appointments").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderBy(i => i.CreatedDate).ToPagedList(page, 30);

                return View(doctor);
            }
        }

        public ActionResult DoctorConfirm(int id)
        {
            var confirm = _db.Doctors.Where(i => i.Id == id).FirstOrDefault();
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("DoctorConfirmList");
        }

        public ActionResult PatientConfirmList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var patient = _db.Patients.Include("PatientRooms").Include("Departman").Include("Appointments").Where(i => i.IsDeleted == false && i.IsConfirm == true).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);
                return View(patient);
            }
        }

        public ActionResult PatientConfirm(int id)
        {
            var confirm = _db.Patients.Where(i => i.Id == id).FirstOrDefault();
            confirm.IsConfirm = true;
            _db.SaveChanges();

            return RedirectToAction("PatientConfirmList");
        }
    }
}