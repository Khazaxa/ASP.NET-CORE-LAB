using lab3b.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3b.Controllers;

public class AlbumController : Controller
{
    private static readonly Dictionary<int, Album> _albums = new Dictionary<int, Album>();

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
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Name, Band, ChartRanking, ReleaseDate, Duration")] Album album, string[] songs)
    {
        if (ModelState.IsValid)
        {
            album.SongList = new Dictionary<int, string>();
            int songId = 1;
            foreach (var song in songs)
            {
                if (!string.IsNullOrWhiteSpace(song))
                {
                    album.SongList.Add(songId++, song);
                }
            }

            album.Id = _albums.Count + 1;
            _albums.Add(album.Id, album);
            return RedirectToAction(nameof(Index));
        }

        return View(album);
    }

    public IActionResult Edit(int id)
    {
        if (!_albums.ContainsKey(id))
        {
            return NotFound();
        }

        return View(_albums[id]);
    }
    
    public IActionResult Details(int id)
    {
        if (_albums.ContainsKey(id))
        {
            var album = _albums[id];
            return View(album);
        }
        else
        {
            return NotFound();
        }
    }

    
    public IActionResult Delete(int id)
    {
        if (!_albums.ContainsKey(id))
        {
            return NotFound();
        }

        return View(_albums[id]);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _albums.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}
