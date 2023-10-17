using lab3a.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3a.Controllers
{
    public class ContactController : Controller
    {
        static readonly Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        static int id = 1;

        public IActionResult Index()
        { 
            return View(_contacts);
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
                model.Id = id++;
                _contacts.Add(model.Id, model);
                return RedirectToAction("Index");
            }
            return View(); // ponownie wyswietl formularz z bledami
        }
    }
}
