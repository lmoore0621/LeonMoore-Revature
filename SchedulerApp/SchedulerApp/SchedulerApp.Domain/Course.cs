using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerApp.Domain
{
    public class Course
    {
        public Course()
        {
            StudentCourses = new List<StudentCourses>();
        }

        public int Id { get; set; }

        public int? ProfessorId { get; set; }

        public string Name { get; set; }

        public int CreditHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public int Length { get; set; }

        public int StudentCapacity { get; set; }

        public virtual Member Professor { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
