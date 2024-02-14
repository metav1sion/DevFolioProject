using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
	public class SkillController : Controller
	{
		DbDevFolioEntities db = new DbDevFolioEntities();

		public ActionResult SkillList()
		{
			var values = db.TblSkill.ToList();
			return View(values);
		}

		[HttpGet] //Sen bir get metodusun denmek isteniyor. Sayfa yüklendiği zaman bana sadece o sayfayı getir demek.
		public ActionResult CreateSkill()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateSkill(TblSkill p)
		{
			db.TblSkill.Add(p);
			db.SaveChanges();
			return RedirectToAction("SkillList");
		}

		public ActionResult DeleteSkill(int id)
		{
			var value = db.TblSkill.Find(id);
			db.TblSkill.Remove(value);
			db.SaveChanges();
			return RedirectToAction("SkillList");
		}

		[HttpGet]
		public ActionResult UpdateSkill(int id)
		{
			var value = db.TblSkill.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateSkill(TblSkill s)
		{
			var value = db.TblSkill.Find(s.SkillID);
			value.SkillTitle = s.SkillTitle;
			value.SkillValue = Convert.ToByte(s.SkillValue);
			db.SaveChanges();

			return RedirectToAction("SkillList");
		}
	}
}
