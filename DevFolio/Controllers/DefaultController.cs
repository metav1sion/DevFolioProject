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
        public PartialViewResult PartialSkill()
        {
	        var values = db.TblSkill.ToList();
	        return PartialView(values);
        }

        public PartialViewResult PartialAboutMe()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
	        var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistic()
        {
			ViewBag.categoryCount = db.TblCategory.Count();
			ViewBag.projectCount = db.TblProject.Count();
			ViewBag.skillCount = db.TblSkill.Count();
			ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
			ViewBag.lastSkillTitleName = db.LastSkillTitle().FirstOrDefault();
			ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
			ViewBag.testimonialCount = db.TblTestimonial.Count();

			return PartialView();
        }

		public PartialViewResult PartialPortfolio()
		{
			var values = db.TblProject.ToList();
			return PartialView(values);
		}

		public PartialViewResult PartialTestimonial()
		{
			var values = db.TblTestimonial.ToList();
            return PartialView(values);
		}

		public PartialViewResult PartialAdress()
		{
            var values = db.TblAdress.ToList();
            return PartialView(values);
		}

		public PartialViewResult PartialSocial()
		{
			var values = db.TblSocialMedia.ToList();
			return PartialView(values);
		}

		[HttpGet]
		public PartialViewResult PartialContact()
		{
			ViewBag.show = false;
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult PartialContact(TblContact p)
		{
			p.IsRead = false;
			p.SendMessageDate = DateTime.Now;
			db.TblContact.Add(p);
			db.SaveChanges();
			ModelState.Clear();
			ViewBag.show = true;
			return PartialView("PartialContact");
		}

	}
}