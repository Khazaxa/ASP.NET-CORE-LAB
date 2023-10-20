using lab3b.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3b.Controllers
{
    public class AlbumController : Controller
    {
        private static Dictionary<int, Album> _albums = new Dictionary<int, Album>();

        public IActionResult Index()
        {
            return View(_albums);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                int id = _albums.Keys.Count != 0 ? _albums.Keys.Max() : 0;
                album.Id = id + 1;
                _albums.Add(album.Id, album);

                return RedirectToAction("Index");
            }
            else
            {
                return View(album);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_albums.ContainsKey(id))
            {
                return View(_albums[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _albums[album.Id] = album;
                return RedirectToAction("Index");
            }
            else
            {
                return View(album);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (_albums.ContainsKey(id))
            {
                return View(_albums[id]);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            var album = _albums.ContainsKey(id) ? _albums[id] : null;

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_albums.ContainsKey(id))
            {
                _albums.Remove(id);
            }

            return RedirectToAction("Index");
        }
    }
}
