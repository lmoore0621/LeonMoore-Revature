using SchedulerApp.Models.Data;
using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace SchedulerApp.Models.Service
{
    public class SchedulerService
    {
        private DataSource db;

        private int FullTimeCreditHours;
        private int MaxCreditHours;

        public SchedulerService()
        {
            db = new DataSource();

            FullTimeCreditHours = int.Parse(ConfigurationManager.AppSettings["FulltimeCourse"]);
            MaxCreditHours = int.Parse(ConfigurationManager.AppSettings["MaxCreditHours"]);
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

        public IEnumerable<Member> SearchMembers(string lastName)
        {
            List<Member> members = db.Members.Where(m => m.LastName.ToLower().Contains(lastName.ToLower())).ToList();

            return members;
        }

        public void CreateMember(Member member)
        {
            db.Members.Add(member);
            db.SaveChanges();
        }

        #region Professor

        public void RegisterStudent(Member student)
        {
            student.RoleName = "Student";
            CreateMember(student);
        }

        public void UpdateCourse(Course course)
        {
            Course courseToUpdate = GetCourse(course.Id);
            db.Entry(courseToUpdate).CurrentValues.SetValues(course);

            db.SaveChanges();
        }

        public Member GetProfessorWithCourses(int professorId)
        {
            Member professor = db.Members.Include(m => m.ProfessorCourses).FirstOrDefault(m => m.Id == professorId);

            return professor;
        }

        public Course GetCourseWithStudents(int courseId)
        {
            Course course = db.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == courseId);

            return course;
        }

        #region Student

        public Member GetStudentWithCourses(int studentId)
        {
            Member student = db.Members.Include(m => m.StudentCourses).FirstOrDefault(m => m.Id == studentId);

            return student;
        }

        public Member GetStudent(int studentId)
        {
            Member student = db.Members.FirstOrDefault(s => s.Id == studentId);
            return student;
        }

        public void AssignCourseToStudent(int courseId, int studentId)
        {
            Course course = db.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == courseId);
            Member student = db.Members.Include(m => m.StudentCourses).FirstOrDefault(m => m.Id == studentId);

            if (!student.StudentCourses.Contains(course) 
                && !student.StudentCourses.Any(c => c.StartTime == course.StartTime && c.StartDate == course.StartDate)
                && !((student.StudentCourses.Sum(c => c.CreditHours) + course.CreditHours) > MaxCreditHours)
                && course.Students.Count() < course.StudentCapacity)
            {
                course.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void AssignCoursesToStudent(IEnumerable<int> courseIds, int studentId)
        {
            foreach (int courseId in courseIds)
            {
                AssignCourseToStudent(courseId, studentId);
            }
        }

        public void RemoveStudentFromCourse(int studentId, int courseId)
        {
            Member student = db.Members.FirstOrDefault(m => m.Id == studentId);
            Course course = db.Courses.FirstOrDefault(c => c.Id == courseId);

            course.Students.Remove(student);
            db.SaveChanges();
        }


        #endregion

        #endregion

        #endregion
    }
}