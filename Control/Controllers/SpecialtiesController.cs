using Control.Models;
using Control.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ControlContext db;
        public SpecialtiesController(ControlContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            IEnumerable<Specialty> Specialities = (IEnumerable<Specialty>)db.Specialties.ToList();
            SpecialtiesViewModel specialtiesVM = new()
            {
                TitleOfPage = "Специальности",
                Specialities = Specialities
            };
            return View(specialtiesVM);
        }
    }
}
