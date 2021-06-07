using Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control.ViewModels
{
    public class SpecialtiesViewModel : BaseViewModel
    {
        public IEnumerable<Specialty> Specialities { get; set; }
    }
}
