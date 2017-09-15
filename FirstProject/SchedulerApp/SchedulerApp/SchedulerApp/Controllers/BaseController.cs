using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Controllers
{
    public class BaseController : Controller
    {
        public Member CurrentUser
        {
            get
            {
                Member member = null;

                if (Session["CurrentUser"] != null)
                {
                    member = (Member)Session["CurrentUser"];
                }

                return member;
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }

        public ActionResult CheckAuthentication()
        {
            if (CurrentUser == null)
            {
                return View("login");
            }

            return null;
        }

    }
}