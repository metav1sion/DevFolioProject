using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
		DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Project
        public ActionResult Index()
        {
	        var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
		public ActionResult CreateProject()
		{
			var values = db.TblCategory.ToList();
			return View(values);
		}

		public ActionResult DeleteProject(int id)
		{
			var value = db.TblProject.Find(id);
			db.TblProject.Remove(value);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult CreateProject(TblProject project, HttpPostedFileBase file)
		{
			if (file != null && file.ContentLength > 0)
			{
				var fileName = Path.GetFileName(file.FileName);
				var path = Path.Combine(Server.MapPath("~/img"), fileName);
				file.SaveAs(path);

				project.CoverImageUrl = "/img/" + fileName;
				//project.CoverImageUrl = path;
			}

			project.CreatedDate = DateTime.Now;
			db.TblProject.Add(project);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateProject(int id)
		{
			var values = db.TblProject.Find(id);
			List<SelectListItem> category = (from i in db.TblCategory.ToList()
				select new SelectListItem
				{
					Text = i.CategoryName,
					Value = i.CategoryID.ToString()
				}).ToList();
			//var categories = db.TblCategory.ToList();
			ViewBag.data = category;

			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateProject(TblProject p, HttpPostedFileBase file)
		{
			var value = db.TblProject.Find(p.ProjectID);
			value.ProjectTitle = p.ProjectTitle;
			value.ProjectDescription = p.ProjectDescription;

			
			value.ProjectCategory = p.TblCategory.CategoryID;
			

			if (file != null && file.ContentLength > 0)
			{
				var fileName = Path.GetFileName(file.FileName);
				var path = Path.Combine(Server.MapPath("~/img"), fileName);
				file.SaveAs(path);

				value.CoverImageUrl = "/img/" + fileName;
				//project.CoverImageUrl = path;
			}

			db.SaveChanges();
			

			return RedirectToAction("Index");

		}
	}
}