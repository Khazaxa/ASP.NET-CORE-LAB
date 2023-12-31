﻿using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;
using Lab3___zadanieContextConnection.Entities;
using System.Linq;
using Lab3___zadanieContextConnection;
using Microsoft.AspNetCore.Authorization;

namespace Lab3zadanie.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly AppDbContext _context;

        public AlbumController(IAlbumService albumService, AppDbContext context)
        {
            _albumService = albumService;
            _context = context;
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

        [HttpGet]
        public IActionResult CreateSong(int id)
        {
            var songModel = new Song { AlbumId = id };
            return View(songModel);
        }

        [HttpPost]
        public IActionResult CreateSong(Song model)
        {
            if (ModelState.IsValid)
            {
                var songEntity = new SongEntity
                {
                    Title = model.Title,
                    Duration = model.Duration,
                    AlbumId = model.AlbumId
                };

                _context.Songs.Add(songEntity);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = model.AlbumId });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteSong(int id, int albumId)
        {
            var song = _context.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = albumId });
        }


    }
}
