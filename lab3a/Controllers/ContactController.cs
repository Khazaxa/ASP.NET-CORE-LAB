using lab3a.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3a.Controllers
{
    //[Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        public IActionResult PagedIndex(int page = 1, int size = 2)
        {
            return View(_contactService.FindPage(page, size));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Contact
            {
                OrganizationList = _contactService.FindAllOrganizations()
                    .Select(o => new SelectListItem
                    {
                        Value = o.Id.ToString(),
                        Text = o.Name
                    }).ToList()
            };

            return View(model);
        }

        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateApi(Contact model)
        {
              if (ModelState.IsValid)
            {
                _contactService.Add(model); 
                return RedirectToAction("Index"); 
            } 
            return View();
        }


        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
    }
}
