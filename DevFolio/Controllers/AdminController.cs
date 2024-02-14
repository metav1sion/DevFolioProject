using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AdminController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Admin
        public ActionResult AdminList()
        {
	        var values = db.TblAdmin.ToList();
            return View(values);
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = db.TblAdmin.FirstOrDefault(x=>x.AdminID == id);
            db.TblAdmin.Remove(value);
            db.SaveChanges();
	        return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
	        return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(TblAdmin a)
        {
            db.TblAdmin.Add(a);
            db.SaveChanges();
	        return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
	        var value = db.TblAdmin.FirstOrDefault(x => x.AdminID == id);
	        return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin a)
        {
            var value = db.TblAdmin.FirstOrDefault(x=>x.AdminID == a.AdminID);
            value.Username = a.Username;
            value.Password = a.Password;
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
	}
}