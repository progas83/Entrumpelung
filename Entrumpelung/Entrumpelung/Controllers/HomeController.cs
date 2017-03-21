using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entrumpelung.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public void UpdateCity(string selectedCity)
        {
            HttpContext.Response.Cookies["City"].Value = selectedCity;
            ViewBag.City = selectedCity;
        }

        public ActionResult Index()
        {
            ViewBag.City = HttpContext.Response.Cookies["City"].Value;// "Test Berlin";
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
    }
}