﻿using System;
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

        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Course> courses = new List<Course>();
            string userRole = ClaimTypes.Role.ToLower();
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

            if (User.HasClaim(userRole, "registrar"))
            {
                courses = db.Courses.ToList();
            }
            else if (User.HasClaim(userRole, "professor"))
            {
                courses = service.GetProfessorWithCourses(userId).ProfessorCourses.ToList();
            }
            else
            {
                courses = service.GetStudentWithCourses(userId).StudentCourses.Select(sc => sc.Course).ToList();
            }

            return View(courses);
        }

        public IActionResult CreateMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember([FromForm] Member member)
        {
            service.CreateMember(member);
                                                                                                            
            return RedirectToAction("Members");
        }

        public IActionResult CreateCourse()
        {
            ICollection<Member> professors = service.GetAllProfessors();

            return View(professors);
        }

        [HttpPost]
        public IActionResult CreateCourse([FromForm] Course course)
        {
            service.CreateCourse(course);

            return RedirectToAction("Courses");
        }

        public IActionResult Courses()
        {
            IEnumerable<Course> courses = service.GetAllCourses();

            return View(courses);
        }

        public IActionResult Members()
        {
            IEnumerable<Member> members = service.GetAllMembers();

            return View(members);
        }

        public IActionResult AvailableCourses()
        {
            IEnumerable<Course> courses = service.GetAvailableCourses();
            if (TempData["ErrorMessage"] != null)
            {
                ViewData["ErrorMessage"] = TempData["ErrorMessage"].ToString();
            }
            return View(courses);
        }

        [HttpPost]
        public IActionResult AddCourse(int studentId, int courseId)
        {
            string errorMessage = string.Empty;
            try
            {
                service.AssignCourseToStudent(courseId, studentId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            TempData["ErrorMessage"] = errorMessage;

            return RedirectToAction("AvailableCourses");
        }

        public IActionResult RemoveStudentCourse(int courseId, int studentId)
        {
            service.RemoveStudentFromCourse(studentId, courseId);

            return View();
        }
    }
}