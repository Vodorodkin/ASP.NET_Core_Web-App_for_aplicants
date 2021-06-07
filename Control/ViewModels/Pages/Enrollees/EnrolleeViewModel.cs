using Control.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control.ViewModels.Pages.Enrollees
{
    public class EnrolleeViewModel : BaseViewModel
    {
        public EnrolleeViewModel(List<Specialty> specialties, int? speciality = 0)
        {
            specialties.Insert(0, new Specialty { Short = "Все", Id = 0 });
            Specialties = new SelectList(specialties, "Id", "Short", speciality);
        }
        public Enrollee Enrollee { get; set; }
        public SelectList Specialties { get; private set; }
    }
}
