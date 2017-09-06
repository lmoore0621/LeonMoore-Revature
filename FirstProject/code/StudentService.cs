using Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Service
{
    public class StudentService
    {
        protected DataLogic db;

        public StudentService()
        {
            db = new DataLogic();
        }
    }
}
