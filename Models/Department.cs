using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Faculties = new HashSet<Faculty>();
            Subjects = new HashSet<Subject>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
