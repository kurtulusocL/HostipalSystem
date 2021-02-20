using HospitalSystem.Data.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _db;

        public AdminController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminList(int page = 1)
        {
            using (_db = new ApplicationDbContext())
            {
                var admin = _db.Users.OrderByDescending(i => i.Birthdate).ToPagedList(page, 10);
                return View(admin);
            }
        }

        public ActionResult DeleteAdmin(string id)
        {
            using (_db = new ApplicationDbContext())
            {
                var deleteAdmin = _db.Users.Find(id);
                if (deleteAdmin != null)
                {
                    _db.Users.Remove(deleteAdmin);
                    _db.SaveChanges();
                }
                return RedirectToAction("AdminList");
            }
        }

        public ActionResult AdminInfo(string userId)
        {
            userId = Convert.ToString(Session["adminID"]);
            using (_db = new ApplicationDbContext())
            {
                var information = _db.Users.Where(i => i.Id == userId).OrderBy(i => i.NameLastname).ToList();
                return PartialView("_AdminInfo", information);
            }
        }

        public ActionResult AdminInformation(string userId)
        {
            userId = Convert.ToString(Session["adminID"]);
            using (_db = new ApplicationDbContext())
            {
                var information = _db.Users.Where(i => i.Id == userId).OrderBy(i => i.NameLastname).ToList();
                return PartialView("_AdminInformation", information);
            }
        }

        public ActionResult GetAdminList()
        {
            using (_db = new ApplicationDbContext())
            {
                var adminList = _db.Users.OrderBy(i => i.NameLastname).ToList();
                return PartialView("_GetAdminList", adminList);
            }
        }

        public ActionResult AsistanAdminList()
        {
            using (_db = new ApplicationDbContext())
            {
                var asistanAdmin = _db.Users.OrderBy(i => i.NameLastname).ToList();
                return PartialView("_AsistanAdminList", asistanAdmin);
            }
        }

        public ActionResult HelperAdminList()
        {
            using (_db = new ApplicationDbContext())
            {
                var helperAdmin = _db.Users.OrderBy(i => i.NameLastname).ToList();
                return PartialView("_HelperAdminList", helperAdmin);
            }
        }

        public ActionResult UserList()
        {
            using (_db = new ApplicationDbContext())
            {
                var userList = _db.Users.OrderBy(i => i.NameLastname).ToList();
                return PartialView("_UserList", userList);
            }
        }
    }
}