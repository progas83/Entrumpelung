using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entrumpelung.Controllers
{
    public class UserIDAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           // var res = filterContext.HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
            
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // base.OnActionExecuting(filterContext);
          //  var res = filterContext.HttpContext.Response.Cookies["UserID"].Value = Guid.NewGuid().ToString();
        }
    }
}