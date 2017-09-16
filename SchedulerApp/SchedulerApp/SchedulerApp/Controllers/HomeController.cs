using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SchedulerApp.Domain;
using SchedulerApp.Data;
using SchedulerApp.Client.Models;

namespace SchedulerApp.Client.Controllers
{
    public class HomeController : Controller
    {
        private DataSource db = new DataSource();
        private SchedulerService service = new SchedulerService();
        private Member CurrentUser = new Member();

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Course> courses = new List<Course>();

            if (User.HasClaim(ClaimTypes.Role, "registrar"))
            {
                courses = db.Courses.ToList();
            }
            else if (User.HasClaim(ClaimTypes.Role, "professor"))
            {
                courses = service.GetProfessorWithCourses(CurrentUser.Id).ProfessorCourses;
            }

            return View(courses);
        }
    }
}