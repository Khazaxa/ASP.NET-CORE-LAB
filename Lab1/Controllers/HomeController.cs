using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calculator(double? a, double? b, Operator op)
        {
            if (a.HasValue && b.HasValue)
            {
                double result = 0;

                switch (op)
                {
                    case Operator.Add:
                        result = a.Value + b.Value;
                        break;
                    case Operator.Sub:
                        result = a.Value - b.Value;
                        break;
                    case Operator.Mul:
                        result = a.Value * b.Value;
                        break;
                    case Operator.Div:
                        if (b != 0)
                        {
                            result = a.Value / b.Value;
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "B cannot be zero for division.";
                            return View();
                        }
                        break;
                    default:
                        ViewBag.ErrorMessage = "Invalid operator.";
                        return View();
                }

                ViewBag.A = a;
                ViewBag.B = b;
                ViewBag.Operator = op;
                ViewBag.Result = result;
            }
            else
            {
                ViewBag.ErrorMessage = "Both 'a' and 'b' must be provided as numeric values.";
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}