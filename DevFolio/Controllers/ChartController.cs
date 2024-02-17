using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ChartController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Chart
        public ActionResult ChartList()
        {
            return View();
        }

        public PartialViewResult ChartHead()
        {
	        return PartialView();
        }
        public PartialViewResult ChartJS()
        {
	        var value = db.TblProject.ToList();
	        ViewBag.asp =  value.FindAll(x => x.TblCategory.CategoryID == 1).Count();
	        ViewBag.flutter =  value.FindAll(x => x.TblCategory.CategoryID == 2).Count();
	        ViewBag.py =  value.FindAll(x => x.TblCategory.CategoryID == 3).Count();
	        ViewBag.cpp =  value.FindAll(x => x.TblCategory.CategoryID == 4).Count();
	        ViewBag.js =  value.FindAll(x => x.TblCategory.CategoryID == 5).Count();
	        ViewBag.php =  value.FindAll(x => x.TblCategory.CategoryID == 7).Count();
	        ViewBag.isReadTrue = db.TrueCount().FirstOrDefault();
	        ViewBag.isReadFalse = db.FalseCount().FirstOrDefault();
	        var value2 = db.MessageLastTenDays().ToList();
			return PartialView(value2);
        }

        public PartialViewResult AllChart()
        {
	        return PartialView();
        }
	}
}