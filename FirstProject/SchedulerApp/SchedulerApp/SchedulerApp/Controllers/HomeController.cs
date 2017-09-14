using SchedulerApp.Models.Data;
using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Controllers
{
    public class HomeController : Controller
    {
        private DataSource db = new DataSource();

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Course> courses = db.Courses.ToList();

            return View(courses);
        }

        // GET: Home/Details/5
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
            try
            {
                // TODO: Add insert logic here
                db.Courses.Add(course);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
