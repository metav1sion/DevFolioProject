using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ServiceController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Service
        public ActionResult ServiceList()
        {
	        var values = db.TblService.ToList();

            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
	        var value = db.TblService.FirstOrDefault(x => x.ServideID == id);
            db.TblService.Remove(value);
            db.SaveChanges();

            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public ActionResult CreateService()
        {
	        return View();
        }
        [HttpPost]
        public ActionResult CreateService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();

	        return RedirectToAction("ServiceList");
		}

        [HttpGet]
        public ActionResult UpdateService(int id)
        {
	        var value = db.TblService.FirstOrDefault(x => x.ServideID == id);
	        return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
	        var value = db.TblService.FirstOrDefault(x => x.ServideID == p.ServideID);
            value.Description = p.Description;
            value.ServiceTitle = p.ServiceTitle;
            value.ServiceImgUrl = p.ServiceImgUrl;
            db.SaveChanges();
	        return RedirectToAction("ServiceList");
		}
	}
}