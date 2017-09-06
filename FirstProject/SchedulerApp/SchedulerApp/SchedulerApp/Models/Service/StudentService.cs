using SchedulerApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Models.Service
{
    public class StudentService
    {
        protected DataLogic dl;

        public StudentService()
        {
            dl = new DataLogic();
        }
    }
}
