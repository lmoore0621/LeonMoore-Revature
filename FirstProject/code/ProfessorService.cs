using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Service
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


        protected void CreateMember(Member member)
        {

        }
    }
}
