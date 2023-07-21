using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Degree
    {
        public int DegreeId { get; set; }
        public int FacultyId { get; set; }
        public string Degree1 { get; set; }
        public string Specialiation { get; set; }
        public int DegreeYear { get; set; }
        public string Grade { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
