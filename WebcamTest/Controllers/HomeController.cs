using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebcamTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Image()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Image(string img)
        {
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            SaveImage(fileName, img);
            return View();
        }

        private void SaveImage(string fileName, string base64)
        {
            base64 = base64.Replace("data:image/png;base64,", "");
            var path = Server.MapPath("~/images/" + fileName + ".png");
            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64));
        }
    }
}