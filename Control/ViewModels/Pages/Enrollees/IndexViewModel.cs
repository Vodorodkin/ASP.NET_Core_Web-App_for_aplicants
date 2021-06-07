using Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Control.ViewModels.Functional;

namespace Control.ViewModels.Pages.Enrollees
{
    public class IndexViewModel : BaseViewModel
    {
        public IEnumerable<Enrollee> Enrollees { get; set; }
        public PaginationViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }

    }
}
