using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
			return PartialView();
		}
        public PartialViewResult PartialNavbar()
        {
	        return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
	        var values = db.TblFeature.ToList();
	        return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
	        var values = db.TblProfile.ToList();
	        return PartialView(values);
        }
	}
}