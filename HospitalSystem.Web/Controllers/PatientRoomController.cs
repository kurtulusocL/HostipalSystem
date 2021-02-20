using HospitalSystem.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Web.Controllers
{
    public class PatientRoomController : Controller
    {
        ApplicationDbContext _db;

        public PatientRoomController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index(int? id, int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var patientRoom = _db.PatientRooms.Include("Patient").Where(i => i.IsDeleted == false && i.PatientId == id).OrderByDescending(i => i.CreatedDate).ToPagedList(page, 25);

                return View(patientRoom);
            }
        }

        public ActionResult Delete(int id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteRoom = _db.PatientRooms.Find(id);
                if (deleteRoom != null)
                {
                    _db.PatientRooms.Remove(deleteRoom);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}