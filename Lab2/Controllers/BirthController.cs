using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;

namespace Lab2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BirthForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BirthResult([FromForm] Birth model)
        {
            if (!ModelState.IsValid)
            {
                return View("BirthForm", model);
            }
            Console.WriteLine("Prawidłowe dane");
            return View(model);
        }
    }
}
