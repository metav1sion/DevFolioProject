using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
using Newtonsoft.Json.Linq;

namespace DevFolio.Controllers
{
    public class TestimonialController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Testimonial
        public ActionResult TestimonialList()
        {
	        var values = db.TblTestimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
	        return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p, HttpPostedFileBase file)
        {
	        p.Status = false;
			if (file != null && file.ContentLength > 0)
			{
				var fileName = Path.GetFileName(file.FileName);
				var path = Path.Combine(Server.MapPath("~/img"), fileName);
				file.SaveAs(path);

				p.ImageUrl = "/img/" + fileName;
			}
			db.TblTestimonial.Add(p);
            db.SaveChanges();
	        return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
	        var value = db.TblTestimonial.Find(id);
	        db.TblTestimonial.Remove(value);
	        db.SaveChanges();
	        return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
	        var value = db.TblTestimonial.Find(id);
	        return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p, HttpPostedFileBase file)
        {
	        var value = db.TblTestimonial.Find(p.TestimonialID);
            value.NameSurname = p.NameSurname;
            value.Description = p.Description;
            value.Status = true;
            if (file != null && file.ContentLength > 0)
            {
	            var fileName = Path.GetFileName(file.FileName);
	            var path = Path.Combine(Server.MapPath("~/img"), fileName);
	            file.SaveAs(path);

	            value.ImageUrl = "/img/" + fileName;
	            //project.CoverImageUrl = path;
            }
			db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
	}
}