using Entrumpelung.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entrumpelung.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }
    }

    public class UserIDAttribute : ActionFilterAttribute
    {

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }


        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{

        //    //if()
        //    // var res = filterContext.HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();

        //}

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    // base.OnActionExecuting(filterContext);
        //    //  var res = filterContext.HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
        //    if (string.IsNullOrEmpty(filterContext.HttpContext.Response.Cookies["UserID"].Value))
        //    {
        //        Guid createdID = Guid.NewGuid();


        //        using (var con = new InfoContext())
        //        {
        //            User user = new User() { UnicIdentic = createdID.ToString() };
        //            con.Users.Add(user);
        //            con.SaveChanges();
        //            SetupCityUserCookies(user.UnicIdentic, filterContext, con);
        //        }
        //    }
        //}

        //private void SetupCityUserCookies(string userGuid, ActionExecutingContext filterContext, InfoContext con)
        //{
        //    User user = con.Users.Where(u => u.UnicIdentic.Equals(userGuid)).FirstOrDefault();
        //    if (user != null)
        //    {
        //        string cityName = string.IsNullOrEmpty(user.City) ? "Default City" : user.City;
        //        City city = con.Cities.Where(c => c.CityName.Equals(cityName)).FirstOrDefault();
        //        SetupCookies(city, filterContext);
        //    }
        //}

        //private void SetupCookies(City city, ActionExecutingContext filterContext)
        //{
        //    HttpCookie cookie = new HttpCookie("City", city != null ? city.CityName : "Default City");
        //    cookie.Expires = DateTime.Now.AddDays(30);
        //    filterContext.HttpContext.Response.Cookies.Add(cookie);

        //    cookie = new HttpCookie("Tel1", city != null ? city.CityTel1 : "00000000000000");
        //    cookie.Expires = DateTime.Now.AddDays(30);
        //    filterContext.HttpContext.Response.Cookies.Add(cookie);
        //}
    }
}