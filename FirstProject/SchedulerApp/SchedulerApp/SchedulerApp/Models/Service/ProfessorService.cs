using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Models.Service
{
    public class ProfessorService : StudentService
    {
        public void RegisterStudent(Member student)
        {
            if (student.RoleName.ToLower() == "student")
            {
                CreateMember(student);
            }
        }

        public IEnumerable<Member> GetStudentsPerCourse(int courseId)
        {
            IEnumerable<Member> students = dl.GetStudentsByCourse(courseId);
            return students;
        }


        protected void CreateMember(Member member)
        {

        }
    }
}
