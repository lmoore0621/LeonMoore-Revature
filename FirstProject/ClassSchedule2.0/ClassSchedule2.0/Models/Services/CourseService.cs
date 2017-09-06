using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassSchedule2._0.Models.ScheduleDb;

namespace ClassSchedule2._0.Models.Services
{
    public class CourseService
    {
        private SchedularDbEntities db = new SchedularDbEntities();

        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            List<Course> courses = db.Courses.OrderBy(c => c.Name).ToList();
            return courses;
        }

        public Course GetCourse(int courseId)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Id == courseId);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            Course courseToUpdate = db.Courses.FirstOrDefault(c => c.Id == course.Id);
            db.Entry(courseToUpdate).OriginalValues.SetValues(course);

            db.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            Course course = GetCourse(courseId);
            DeleteCourse(course);
        }
    }
}