﻿using System;
using System.Collections.Generic;

namespace SchedulerApp.Domain
{
    public class Member
    {
        public Member()
        {
            ProfessorCourses = new List<Course>();
            StudentCourses = new List<StudentCourses>();
        }

        public int Id { get; set; }

        public string RoleName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Course> ProfessorCourses { get; set; }

        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
