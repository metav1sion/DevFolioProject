using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AboutController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();

		// GET: About
		[Authorize]
		public ActionResult AboutList()
        {
	        var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
	        return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout a)
        {
            db.TblAbout.Add(a);
            db.SaveChanges();
	        return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
	        var value = db.TblAbout.Find(id);
            db.TblAbout.Remove(value);
            db.SaveChanges();
			return RedirectToAction("AboutList");
		}

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
	        var value = db.TblAbout.Find(id);
	        return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout a)
        {
	        var value = db.TblAbout.Find(a.AboutID);
            value.AboutTitle = a.AboutTitle;
            value.Description = a.Description;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}