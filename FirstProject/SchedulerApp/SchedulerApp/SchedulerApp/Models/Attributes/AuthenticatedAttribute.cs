using System;
using System.Collections.Generic;
using System.Linq;
using SchedulerApp.Controllers;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Models.Attributes
{
    public class AuthenticatedAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BaseController baseCtrl = (BaseController)filterContext.Controller;

            ActionResult actionResult = baseCtrl.CheckAuthentication();
            if (actionResult != null)
            {
                filterContext.Result = actionResult;
            }
        }
    }
}