using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;
using AlbumData.Entities;
using System.Linq;

namespace Lab3zadanie.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public IActionResult Index()
        {
            var albums = _albumService.FindAll().Select(AlbumMapper.FromEntity).ToList();
            return View(albums);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Album());
        }

        [HttpPost]
        public IActionResult Create(Album model)
        {
            if (ModelState.IsValid)
            {
                var albumEntity = AlbumMapper.ToEntity(model);
                _albumService.Add(albumEntity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var albumEntity = _albumService.FindById(id);
            if (albumEntity == null)
            {
                return NotFound();
            }

            var model = AlbumMapper.FromEntity(albumEntity);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Album model)
        {
            if (ModelState.IsValid)
            {
                var albumEntity = AlbumMapper.ToEntity(model);
                var existingAlbum = _albumService.FindById(model.AlbumId);
                if (existingAlbum == null)
                {
                    return NotFound();
                }

                _albumService.Update(albumEntity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var album = _albumService.FindById(id);
            if (album == null)
            {
                return NotFound();
            }

            return View(AlbumMapper.FromEntity(album));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var existingAlbum = _albumService.FindById(id);
            if (existingAlbum == null)
            {
                return NotFound();
            }

            _albumService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var albumEntity = _albumService.FindById(id);
            if (albumEntity == null)
            {
                return NotFound();
            }

            var model = AlbumMapper.FromEntity(albumEntity);
            return View(model);
        }
    }
}
