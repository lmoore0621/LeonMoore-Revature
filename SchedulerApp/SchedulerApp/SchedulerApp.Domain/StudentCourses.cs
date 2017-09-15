using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerApp.Domain
{
    public class StudentCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Member Student { get; set; }
        public Course Course { get; set; }
    }
}
