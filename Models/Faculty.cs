using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Degrees = new HashSet<Degree>();
            Grants = new HashSet<Grant>();
            Publications = new HashSet<Publication>();
            WorkHistories = new HashSet<WorkHistory>();
        }

        public int FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int DeptId { get; set; }
        public int DesignationId { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
        public virtual ICollection<Grant> Grants { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<WorkHistory> WorkHistories { get; set; }
    }
}
