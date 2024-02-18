using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
using System.Web.Security;

namespace DevFolio.Controllers
{
    public class LoginController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
		// GET: Login
		[AllowAnonymous]
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
		[HttpPost]
		public ActionResult Index(TblAdmin p)
		{
			var adminuserinfo = db.TblAdmin.FirstOrDefault(x=>x.Username == p.Username && x.Password == p.Password);
			if (adminuserinfo != null)
			{
				FormsAuthentication.SetAuthCookie(adminuserinfo.Username,false);
				Session["Username"]=adminuserinfo.Username;
				return RedirectToAction("ChartList", "Chart");
			}
			else
			{
				return RedirectToAction("Index");
			}
	        return View();
        }
	}
}