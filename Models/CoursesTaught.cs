using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class CoursesTaught
    {
        public int CourseId { get; set; }
        public int SubjectId { get; set; }
        public int FacultyId { get; set; }
        public DateTime FirstDateTaught { get; set; }

        public virtual Course Course { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
