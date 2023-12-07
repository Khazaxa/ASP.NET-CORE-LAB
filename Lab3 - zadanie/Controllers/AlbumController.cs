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
            var album = _albumService.FindById(id);
            if (album == null)
            {
                return NotFound();
            }

            var model = new Album
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Band = album.Band,
                ChartPosition = album.ChartPosition,
                ReleaseYear = album.ReleaseYear,
                Duration = album.Duration,
                Genre = album.Genre
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Update(Album model)
        {
            if (ModelState.IsValid)
            {
                var existingAlbum = _albumService.FindById(model.AlbumId);
                if (existingAlbum == null)
                {
                    return NotFound();
                }

                existingAlbum.Title = model.Title;
                existingAlbum.Band = model.Band;
                existingAlbum.ChartPosition = model.ChartPosition;
                existingAlbum.ReleaseYear = model.ReleaseYear;
                existingAlbum.Duration = model.Duration;
                existingAlbum.Genre = model.Genre;

                _albumService.Update(existingAlbum);

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
