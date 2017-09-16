using SchedulerApp.Models.Data;
using SchedulerApp.Models.Model;
using SchedulerApp.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchedulerApp.Models.Attributes;
using System.Web.Mvc;

namespace SchedulerApp.Controllers
{
    public class HomeController : BaseController
    {
        private DataSource db = new DataSource();
        private SchedulerService service = new SchedulerService();

        // GET: Home
        [Authenticated]
        public ActionResult Index()
        {
            IEnumerable<Course> courses = new List<Course>();

            if (CurrentUser.RoleName.ToLower() == "registrar")
            {
                courses = db.Courses.ToList();
            }
            else if (CurrentUser.RoleName.ToLower() == "professor")
            {
                courses = service.GetProfessorWithCourses(CurrentUser.Id).ProfessorCourses;
            }
            else
            {
                courses = service.GetStudentWithCourses(CurrentUser.Id).StudentCourses;
            }

            return View(courses);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            service.CreateCourse(course);
            //try
            //{
            //    // TODO: Add insert logic here
            //    db.Courses.Add(course);
            //    db.SaveChanges();

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Id == id);

            return View(course);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                // TODO: Add update logic here
                Course courseToUpdate = db.Courses.FirstOrDefault(c => c.Id == course.Id);

                db.Entry(courseToUpdate).CurrentValues.SetValues(course);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Id == id);

            db.Courses.Remove(course);
            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            CurrentUser = null;

            ViewBag.Message = "Please enter Username and Password";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Member member = service.AuthenticateUser(username, password);

            if (member != null)
            {
                CurrentUser = member;

                return RedirectToAction("Index");
            }

            ViewBag.Message = "Invalid Username and/or Password";

            return View();
        }
    }
}
