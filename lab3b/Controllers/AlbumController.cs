using Microsoft.AspNetCore.Mvc;

namespace lab3b.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
