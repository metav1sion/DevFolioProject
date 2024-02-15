using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        private DbDevFolioEntities db = new DbDevFolioEntities();

        
		public ActionResult MessageList()
        {
	        var values = db.TblContact.ToList();
            return View(values);
        }


		public ActionResult ReadMessage(int id)
        {
            var value = db.TblContact.FirstOrDefault(x=>x.ContactID==id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }
    }
}