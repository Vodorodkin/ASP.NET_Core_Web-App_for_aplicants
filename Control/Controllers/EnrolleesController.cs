using Control.Models;
using Control.ViewModels;
using Control.ViewModels.Functional;
using Control.ViewModels.Pages.Enrollees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Control.Infrastructure.MethodsForEnrolleeControler;

namespace Control.Controllers
{
    public class EnrolleesController : Controller
    {
        private readonly ControlContext db;

        public EnrolleesController(ControlContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(int? specialityId=0, string name=null, int page = 1, SortState sortList = SortState.NameAsc)
        {
            int pageSize = 3;

            IQueryable<Enrollee> enrollees = db.Enrollees.Include(a => a.Specialty);

            FilterEnrollees(ref enrollees, specialityId, name);

            SortEnrollees(ref enrollees, sortList);

            var count = await enrollees.CountAsync();
            var items = await enrollees.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new()
            {
                TitleOfPage = "Главная",
                PageViewModel = new PaginationViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortList),
                FilterViewModel = new FilterViewModel(db.Specialties.ToList(), specialityId, name),
                Enrollees = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Details(int enrolleeId = 0)
        {
            if (enrolleeId == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                var currentEnrollee = db.Enrollees.Find(enrolleeId);
                EnrolleeViewModel detailsViewModel = new(db.Specialties.ToList(),currentEnrollee.SpecialtyId)
                {
                    TitleOfPage = currentEnrollee.Name,
                    Enrollee = currentEnrollee
                };
                return View(detailsViewModel);
            }
            
        }
        [HttpGet]
        [ActionName("Create")]
        public IActionResult ConfirmCreate(int enrolleeId = 0)
        {

                EnrolleeViewModel createViewModel = new(db.Specialties.ToList())
                {
                    TitleOfPage = "Добавление"
                };
                return View(createViewModel);          
        }
        [HttpPost]
        public IActionResult Create(Enrollee enrollee)
        {
            try
            {
                db.Enrollees.Add(enrollee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        [HttpGet]
        [ActionName("Edit")]
        public IActionResult ConfirmEdit(int enrolleeId = 0)
        {
            if (enrolleeId == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                var currentEnrollee = db.Enrollees.Find(enrolleeId);
                EnrolleeViewModel detailsViewModel = new(db.Specialties.ToList(), currentEnrollee.SpecialtyId)
                {
                    TitleOfPage = currentEnrollee.Name,
                    Enrollee = currentEnrollee
                };
                return View(detailsViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit(Enrollee enrollee)
        {
            try
            {
                db.Enrollees.Update(enrollee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return new BadRequestResult();
            }
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int enrolleeId = 0)
        {
            if (enrolleeId == 0)
            {
                return new BadRequestResult();
            }
            else
            {
                var currentEnrollee = db.Enrollees.Find(enrolleeId);
                EnrolleeViewModel detailsViewModel = new(db.Specialties.ToList(), currentEnrollee.SpecialtyId)
                {
                    TitleOfPage = currentEnrollee.Name,
                    Enrollee = currentEnrollee
                };
                return View(detailsViewModel);
            }
        }
        [HttpPost]
        public IActionResult Delete(Enrollee enrollee)
        {
            try
            {
                db.Enrollees.Remove(enrollee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
}