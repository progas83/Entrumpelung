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
        private Dictionary<string, string> _cityTeldict = new Dictionary<string, string>();
        public HomeController()
        {
            _cityTeldict.Add("Bremen", "49 421 111111111");
            _cityTeldict.Add("Frankfurt am Mein", "49 69 2222222");
            _cityTeldict.Add("Hamburg", "49 40 33 33 33 33");
            _cityTeldict.Add("Hannover", "49 511 44444444");
            _cityTeldict.Add("Minden", "49-571 5555555555");
            _cityTeldict.Add("Bielefeld", "49-521 666666666");
            _cityTeldict.Add("Osnabrück", "49-541 777777777");
            _cityTeldict.Add("Magdeburg", "49-6421 888888888");
            _cityTeldict.Add("Kassel", "49-561 999999999");

            //  HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
        }
        //[HttpPost]
        //public void UpdateCity(string selectedCity)
        //{
        //    var res = HttpContext.Response.Cookies["UserID"].Value;
        //    HttpContext.Response.Cookies["City"].Value = selectedCity;
        //    ViewBag.City = selectedCity;
        //}
        string _defaultNumber = "49 00 0 000 000 0";
        [HttpGet]
        public string UpdateCity(string selectedCity)
        {
            var res = HttpContext.Response.Cookies["UserID"].Value;
            HttpContext.Response.Cookies["City"].Value = selectedCity;
            ViewBag.City = selectedCity;

            string telephoneResult = _defaultNumber;
            if(_cityTeldict.ContainsKey(selectedCity))
            {
                telephoneResult = _cityTeldict[selectedCity];
            }

            return telephoneResult;
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

        public ActionResult Entrumpelung()
        {
            return View();
        }

        public ActionResult Haushaltsauflosung()
        {
            return View();
        }


        public ActionResult Wohnungsauflosung()
        {
            return View();
        }

        public ActionResult Wohnungsraumung()
        {
            return View();
        }

        public ActionResult Tatortreiniger()
        {
            return View();
        }

        public ActionResult SchreibBewertung()
        {
            return View();
        }
    }
}