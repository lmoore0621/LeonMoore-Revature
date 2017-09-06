
using System;
using System.Collections.Generic;

namespace Scheduler.Model
{
    public class Course
    {
        public Course()
        {
            Students = new List<Member>();
        }

        public int Id { get; set; }

        public int? ProfessorId { get; set; }

        public string Name { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartTime { get; set; }

        public int Length { get; set; }

        public int StudentCapacity { get; set; }
        
        public virtual Member Professor { get; set; }

        public virtual ICollection<Member> Students { get; set; }
    }
}
