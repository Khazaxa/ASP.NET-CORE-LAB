﻿using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

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
            if (model.IsValid())
            {
                return View(model);
            }
            return View("Error");
        }
    }
}
