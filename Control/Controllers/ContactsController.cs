using Control.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            ContactsViewModel contactsVM = new()
            {
                TitleOfPage = "Контакты"
            };
            return View(contactsVM);
        }
    }
}
