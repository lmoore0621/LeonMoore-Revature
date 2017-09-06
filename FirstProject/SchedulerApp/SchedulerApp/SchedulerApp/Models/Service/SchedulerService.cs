using SchedulerApp.Models.Data;
using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerApp.Models.Service
{
    public class SchedulerService
    {
        private DataSource db;

        public SchedulerService()
        {
            db = new DataSource();
        }

        #region Registrar

        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public Course GetCourse(int courseId)
        {
           Course course = db.Courses.FirstOrDefault(c => c.Id == courseId);
            return course;
        }

        public void DeleteCourse(int courseId)
        {
            Course course = GetCourse(courseId);
            DeleteCourse(course);
        }

        public void DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            Course courseToUpdate = GetCourse(course.Id);
            db.Entry(courseToUpdate).CurrentValues.SetValues(course);

            db.SaveChanges();
        }

        public void AssignProfessorToCourse(int professorId, int courseId)
        {
            Course course = GetCourse(courseId);
            course.ProfessorId = professorId;

            db.SaveChanges();
        }

        public void AssignStudentToCourse(int studentId, int courseId)
        {
            Course course = GetCourse(courseId);
            Member student = GetStudent(studentId);

            course.Students.Add(student);
            db.SaveChanges();
        }

        #region Professor


        #region Student

        public Member GetStudent(int studentId)
        {
            Member student = db.Members.FirstOrDefault(s => s.Id == studentId);
            return student;
        }

        #endregion

        #endregion

        #endregion
    }
}