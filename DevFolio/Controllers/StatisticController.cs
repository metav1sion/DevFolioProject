using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
	    private DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Statistic
        public ActionResult Index()
        {
	        ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitleName = db.LastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.isReadTrueCount = db.TblContact.Where(x => x.IsRead == true).Count();
            List<int> MessageCount = new List<int>();
            var values = db.MessageLastTenDays().ToList();
            foreach (var item in values)
            {
	            MessageCount.Add((int)item.MessageCount);
            }

            ViewBag.tendaymessage = MessageCount.Sum();
            return View();
        }
    }
}