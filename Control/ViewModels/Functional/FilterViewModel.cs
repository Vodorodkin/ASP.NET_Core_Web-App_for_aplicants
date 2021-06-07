using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Control.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Control.ViewModels.Functional
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Specialty> specialties, int? speciality, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            specialties.Insert(0, new Specialty { Short = "Все", Id = 0 });
            Specialties = new SelectList(specialties, "Id", "Short", speciality);
            SelectedSpeciality = speciality;
            SelectedName = name;
        }
        public SelectList Specialties { get; private set; } 
        public int? SelectedSpeciality { get; private set; }   
        public string SelectedName { get; private set; }   
    }
}
