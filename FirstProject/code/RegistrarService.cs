using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Model;

namespace Scheduler.Service
{
    public class RegistrarService : ProfessorService
    {
        public void CreateCourse(Course course)
        {
            db.CreateCourse(course);
        }

        public Course GetCourse(int courseId)
        {
            Course course = db.GetCourse(courseId);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            db.UpdateCourse(course);
        }

        public void DeleteCourse(int courseId)
        {
            Course course = GetCourse(courseId);
            db.DeleteCourse(course);
        }

        public void AssignProfessorToCourse(int professorId, int courseId)
        {
            Course course = GetCourse(courseId);
            course.ProfessorId = professorId;
            db.Commit();
        }

        public void AssignStudentToCourse(int studentId, int courseId)
        {
            Member student = db.GetMember(studentId);
            Course course = GetCourse(courseId);

            course.Students.Add(student);
            db.Commit();
        }

        public void AssignStudentsToCourse(IEnumerable<int> studentIds, int courseId)
        {
            IEnumerable<Member> students = db.GetMembers(studentIds);
            Course course = GetCourse(courseId);

            foreach (Member student in students)
            {
                course.Students.Add(student);
            }

            db.Commit();
        }
    }
}
