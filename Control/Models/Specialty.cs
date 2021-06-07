using System;
using System.Collections.Generic;

#nullable disable

namespace Control.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            Enrollees = new HashSet<Enrollee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }
        public string PeriodOfStudy { get; set; }
        public string Plan { get; set; }

        public virtual ICollection<Enrollee> Enrollees { get; set; }
    }
}
