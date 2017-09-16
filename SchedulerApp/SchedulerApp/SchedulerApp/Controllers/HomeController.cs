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
            string userRole = ClaimTypes.Role.ToLower();

            if (User.HasClaim(userRole, "registrar"))
            {
                courses = db.Courses.ToList();
            }
            else if (User.HasClaim(userRole, "professor"))
            {
                courses = service.GetProfessorWithCourses(CurrentUser.Id + 1).ProfessorCourses;
            }
            else
            {
                //courses = service.GetStudentWithCourses(CurrentUser.Id).StudentCourses;
            }

            return View(courses);
        }

        
        public IActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            service.CreateMember(member);
                                                                                                            
            return RedirectToAction("Index");
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            service.CreateCourse(course);

            return RedirectToAction("Index");
        }
    }
}