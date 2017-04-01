using Entrumpelung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entrumpelung.Controllers
{
    [NoCache]
    public class HomeController : Controller
    {


     //   private Dictionary<string, string> _cityTeldict = new Dictionary<string, string>();
        public HomeController()
        {

            //_cityTeldict.Add("Bremen", "49 421 111111111");
            //_cityTeldict.Add("Frankfurt am Mein", "49 69 2222222");
            //_cityTeldict.Add("Hamburg", "49 40 33 33 33 33");
            //_cityTeldict.Add("Hannover", "49 511 44444444");
            //_cityTeldict.Add("Minden", "49-571 5555555555");
            //_cityTeldict.Add("Bielefeld", "49-521 666666666");
            //_cityTeldict.Add("Osnabrück", "49-541 777777777");
            //_cityTeldict.Add("Magdeburg", "49-6421 888888888");
            //_cityTeldict.Add("Kassel", "49-561 999999999");

            //using (var context = new InfoContext())
            //{
            //    context.Cities.Add(InitCity("Bremen", "421", "111111111"));
            //    context.Cities.Add(InitCity("Frankfurt am Mein", "69", "2222222"));
            //    context.Cities.Add(InitCity("Hamburg", "40", "33 33 33 33"));
            //    context.Cities.Add(InitCity("Hannover", "511", "44444444"));
            //    context.Cities.Add(InitCity("Minden", "571", "5555555555"));
            //    context.Cities.Add(InitCity("Bielefeld", "521", "666666666"));
            //    context.Cities.Add(InitCity("Osnabrück", "541", "777777777"));
            //    context.Cities.Add(InitCity("Magdeburg", "6421", "888888888"));
            //    context.Cities.Add(InitCity("Kassel", "561", "999999999"));
            //    context.SaveChanges();
            //}

            //using (var con = new InfoContext())
            //{
            //    var c = con.Cities;
            //}
            //  HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
        }

        //private City InitCity(string cityName, string cityCode, string cityTel1)
        //{
        //    City city = new City();
        //    city.CityName = cityName;
        //    city.CityCode = cityCode;
        //    city.CityTel1 = cityTel1;
        //    return city;
        //}
        //[HttpPost]
        //public void UpdateCity(string selectedCity)
        //{
        //    var res = HttpContext.Response.Cookies["UserID"].Value;
        //    HttpContext.Response.Cookies["City"].Value = selectedCity;
        //    ViewBag.City = selectedCity;
        //}
        //string _defaultNumber = "49 00 0 000 000 0";
        [HttpPost]
        public string CallBackOrder(string name, string telephone)
        {
            CallBackManager.CallBackNotify(name, telephone);
            return string.Empty;
        }

        [HttpPost]
        public void SendReview(CustomerReview review)
        {
            review.ReviewDate = DateTime.UtcNow;
            review.CustomerCity = Server.UrlDecode(Request.Cookies.Get("City").Value);
            using (var con = new InfoContext())
            {
                con.CustomerReviews.Add(review);
                con.SaveChanges();
            }
            ModelState.Clear();
            //return View("SchreibBewertung");
        }

        public ActionResult Updatereviews()
        {
            List<CustomerReview> reviews = new List<CustomerReview>();
            using (var con = new InfoContext())
            {
                reviews = con.CustomerReviews.OrderByDescending(d => d.ReviewDate).ToList();
            }

            //  ViewBag.Reviews = reviews;
            return PartialView("ReviewCollectionView", reviews);
        }

        [HttpGet]
        public JsonResult UpdateCity(string selectedCity)
        {
            //User user = null;
            City currentCity = CitiesRepository.GetCity(Server.UrlDecode(selectedCity));
            //var userIdCookie = HttpContext.Request.Cookies.Get("UserID");
            //AddNewCookie("CitySelected", "true", 30);
            //if (userIdCookie == null)
            //{
            //    user = SetupUserID();
            //}
            //using (var con = new InfoContext())
            //{
            //    user = con.Users.Where(u => u.UnicIdentic.Equals(userIdCookie.Value)).FirstOrDefault();
            //    user.City = selectedCity;
                
            //    con.SaveChanges();
            //    currentCity = con.Cities.Where(c => c.CityName.Equals(selectedCity)).FirstOrDefault();
            //}

            //SetupUserCookies(user);
            SetupCityCookies(currentCity);
            var result = Json(currentCity);
            result.ContentEncoding = System.Text.Encoding.UTF8;
            result.ContentType = "JSON";
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;// new JsonResult(new {cityCode =  }) {cityCode: "00" string.Format("{0}{1}",currentCity.CityCode, currentCity.CityTel1);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
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
            List<CustomerReview> reviews = new List<CustomerReview>();
            using (var con = new InfoContext())
            {
                reviews = con.CustomerReviews.OrderByDescending(d => d.ReviewDate).ToList();
            }

            ViewBag.Reviews = reviews;
                return View(new CustomerReview());
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Request.Cookies.Get("City") == null)
            {
                SetupCityCookies(null);
            }
            

        }


        private readonly string defaultCity = "Minden";
        private readonly string defaultCityCode = "0571";
        private readonly string defaultTel1 = "829 45 878";
        private void SetupCityCookies(City city)
        {
            if(city!=null)
            {
                AddNewCookie("City", Server.UrlEncode(city.CityName) , 30);
                AddNewCookie("Tel1", city.CityTel1 , 30);
                AddNewCookie("CityCode",city.CityCode, 30);
            }
            else
            {
                AddNewCookie("City", defaultCity, 30);
                AddNewCookie("Tel1", defaultTel1, 30);
                AddNewCookie("CityCode", defaultCityCode, 30);
            }
        }

        private void AddNewCookie(string cookieName,string cookieValue, int daysToExpires = 0)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
            if (daysToExpires!=0)
            {
                cookie.Expires = DateTime.Now.AddDays(daysToExpires);
            }
            HttpContext.Response.Cookies.Add(cookie);
        }
    }
}