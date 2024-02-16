using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Profile
        [HttpGet]
        public ActionResult ProfileChange()
        {
	        ViewBag.show = false;
	        var value = db.TblProfile.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult ProfileChange(TblProfile p)
        {
	        var value = db.TblProfile.FirstOrDefault();
            value.Email = p.Email;
            value.NameSurname = p.NameSurname;
            value.Phone = p.Phone;
            value.Title = p.Title;
            db.SaveChanges();
            ViewBag.show = true;
			return View();
        }
	}
}