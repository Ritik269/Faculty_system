using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCredits { get; set; }
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }
    }
}
