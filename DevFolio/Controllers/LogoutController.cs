using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevFolio.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
	        FormsAuthentication.SignOut();
	        return RedirectToAction("Index", "Login");
		}
  
    }
}