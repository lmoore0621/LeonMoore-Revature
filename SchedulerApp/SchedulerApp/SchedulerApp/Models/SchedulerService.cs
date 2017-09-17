using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchedulerApp.Data;
using SchedulerApp.Domain;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SchedulerApp.Client.Models
{
    public class SchedulerService
    {
        private DataSource db;

        private int FullTimeCreditHours;
        private int MaxCreditHours;

        public SchedulerService()
        {
            db = new DataSource();

            FullTimeCreditHours = Startup.Configuration.GetValue<int>("FullTimeCreditHours");
            MaxCreditHours = Startup.Configuration.GetValue<int>("MaxCreditHours");
        }

        #region Security
        public Member AuthenticateUser(string username, string password)
        {
            Member member = db.Members.FirstOrDefault(m => m.Username.ToLower() == username.ToLower() && m.Password == password);

            return member;
        }

        #endregion

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

        public ICollection<Member> GetAllProfessors()
        {
            List<Member> professors = db.Members.Where(m => m.RoleName == "professor").OrderBy(m => m.LastName).ToList();

            return professors;
        }

        public void AssignStudentToCourse(int studentId, int courseId)
        {
            Course course = GetCourse(courseId);
            Member student = GetStudent(studentId);
            StudentCourses studentCourses = new StudentCourses() {
                StudentId = studentId,
                Student = student,
                CourseId = courseId,
                Course = course
            };

            course.StudentCourses.Add(studentCourses);
            db.SaveChanges();
        }

        public IEnumerable<Course> GetAvailableCourses()
        {
            List<Course> courses = db.Courses
                .Where(c => c.StartDate > DateTime.Now)
                .OrderBy(c => c.StartDate)
                .ThenBy(c => c.StartTime)
                .ThenBy(c => c.Name).ToList();

            return courses;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> members = db.Members.ToList();

            return members;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            List<Course> courses = db.Courses.ToList();

            return courses;
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
            Member professor = db.Members.Include(m => m.ProfessorCourses).ThenInclude(c => c.Professor).FirstOrDefault(m => m.Id == professorId);

            return professor;
        }

        public Course GetCourseWithStudents(int courseId)
        {
            Course course = db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).FirstOrDefault(c => c.Id == courseId);

            return course;
        }

        #region Student

        public Member GetStudentWithCourses(int studentId)
        {
            Member student = db.Members.Include(m => m.StudentCourses).ThenInclude(sc => sc.Course).ThenInclude(c => c.Professor).FirstOrDefault(m => m.Id == studentId);

            return student;
        }

        public Member GetStudent(int studentId)
        {
            Member student = db.Members.FirstOrDefault(s => s.Id == studentId);
            return student;
        }

        public void AssignCourseToStudent(int courseId, int studentId)
        {
            Course course = db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).FirstOrDefault(c => c.Id == courseId);
            Member student = db.Members.Include(m => m.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefault(m => m.Id == studentId);

            if (student.StudentCourses.Any(sc => sc.CourseId == courseId))
            {
                throw new Exception("The course you are trying to add is already in your schedule.");
            }
            else if (student.StudentCourses.Any(sc => sc.Course.StartTime == course.StartTime && sc.Course.StartDate == course.StartDate))
            {
                throw new Exception("This course is at the same time as another course in your schedule.");
            }
            else if (((student.StudentCourses.Sum(sc => sc.Course.CreditHours) + course.CreditHours) > MaxCreditHours))
            {
                throw new Exception("Adding this course to your schedule will exceed the amount of credit hours allowed.");
            }
            else if (course.StudentCourses.Count() >= course.StudentCapacity)
            {
                throw new Exception("The course you are attemptint to add is already full.");
            }

            StudentCourses studentCourses = new StudentCourses()
            {
                StudentId = studentId,
                Student = student,
                CourseId = courseId,
                Course = course
            };

            course.StudentCourses.Add(studentCourses);
            db.SaveChanges();
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

            StudentCourses studentCourses = new StudentCourses()
            {
                StudentId = studentId,
                Student = student,
                CourseId = courseId,
                Course = course
            };

            course.StudentCourses.Remove(studentCourses);
            db.SaveChanges();
        }


        #endregion

        #endregion

        #endregion
    }
}
