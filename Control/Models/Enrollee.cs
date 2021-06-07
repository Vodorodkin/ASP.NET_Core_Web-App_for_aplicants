using System;
using System.Collections.Generic;

#nullable disable

namespace Control.Models
{
    public partial class Enrollee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Passport { get; set; }
        public DateTime Date { get; set; }
        public int? SpecialtyId { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
