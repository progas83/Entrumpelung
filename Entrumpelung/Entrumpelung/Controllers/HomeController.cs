using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entrumpelung.Controllers
{
    [UserID]
    public class HomeController : Controller
    {
        public HomeController()
        {
          //  HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
        }
        [HttpPost]
        public void UpdateCity(string selectedCity)
        {
            var res = HttpContext.Response.Cookies["UserID"].Value;
            HttpContext.Response.Cookies["City"].Value = selectedCity;
            ViewBag.City = selectedCity;
        }

        public ActionResult Index()
        {
            var res = HttpContext.Response.Cookies["UserID"].Value;
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