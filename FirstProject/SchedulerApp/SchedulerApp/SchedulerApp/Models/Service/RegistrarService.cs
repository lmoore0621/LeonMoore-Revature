using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerApp.Models.Model;

namespace SchedulerApp.Models.Service
{
    public class RegistrarService : ProfessorService
    {
        public void CreateCourse(Course course)
        {
            dl.CreateCourse(course);
        }

        public Course GetCourse(int courseId)
        {
            Course course = dl.GetCourse(courseId);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            dl.UpdateCourse(course);
        }

        public void DeleteCourse(int courseId)
        {
            Course course = GetCourse(courseId);
            dl.DeleteCourse(course);
        }

        public void AssignProfessorToCourse(int professorId, int courseId)
        {
            Course course = GetCourse(courseId);
            course.ProfessorId = professorId;
            dl.Commit();
        }

        public void AssignStudentToCourse(int studentId, int courseId)
        {
            Member student = dl.GetMember(studentId);
            Course course = GetCourse(courseId);

            course.Students.Add(student);
            dl.Commit();
        }

        public void AssignStudentsToCourse(IEnumerable<int> studentIds, int courseId)
        {
            IEnumerable<Member> students = dl.GetMembers(studentIds);
            Course course = GetCourse(courseId);

            foreach (Member student in students)
            {
                course.Students.Add(student);
            }

            dl.Commit();
        }
    }
}
