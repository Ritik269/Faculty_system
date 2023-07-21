using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Publication
    {
        public int PublicationId { get; set; }
        public int FacultyId { get; set; }
        public string PublicationTiltle { get; set; }
        public string ArticleName { get; set; }
        public string PublisherName { get; set; }
        public string PublicationLocation { get; set; }
        public DateTime CitationDate { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
