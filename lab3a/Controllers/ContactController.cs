using lab3a.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3a.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                
                // dodanie modelu do aplikacji
                return RedirectToAction("Index");
            }
            return View(); // ponownie wyswietl formularz z bledami
        }
    }
}
