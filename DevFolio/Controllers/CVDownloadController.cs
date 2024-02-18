using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class CVDownloadController : Controller
    {
		// GET: CVDownload
		public FileResult DownloadCV()
		{
			// cv.pdf dosyasının tam yolu
			string filePath = Server.MapPath("~/file/cv.pdf");

			// Dosyayı indirme işlemi
			return File(filePath, "application/pdf", "cv.pdf");
		}
	}
}
