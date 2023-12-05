using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3zadanie.Controllers
{
    public class SongsController : Controller
    {
        // Załóżmy, że masz serwis IAlbumService
        private readonly IAlbumService _albumService;


        public SongsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }



        public IActionResult Index(int id)
        {
            var album = _albumService.FindById(id); // Zakładając, że ta metoda zwraca album
            if (album == null)
            {
                // Obsługa sytuacji, gdy album nie został znaleziony
                return NotFound();
            }

            ViewBag.AlbumId = id;
            ViewBag.AlbumTitle = album.Title; // Przekazanie nazwy albumu do widoku

            return View("~/Views/Songs/Index.cshtml");
        }


        [HttpGet]
        public IActionResult Create(int albumId)
        {
            var model = new SongList { AlbumId = albumId };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SongList model)
        {
            if (ModelState.IsValid)
            {
                // Logika dodawania piosenki do bazy danych
                // Na przykład: _albumService.AddSong(model);

                // Przekieruj użytkownika do akcji "SongList" z identyfikatorem albumu
                return RedirectToAction("SongList", new { id = model.AlbumId });
            }
            return View(model);
        }



        // Tutaj możesz dodać dodatkowe akcje dotyczące piosenek
    }
}
