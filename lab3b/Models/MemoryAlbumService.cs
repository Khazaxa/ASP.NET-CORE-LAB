using System.Collections.Generic;
using System.Linq;
using lab3b.Models;

namespace lab3b.Models;

public class MemoryAlbumService : IAlbumService
{
    private readonly List<Album> _albums = new List<Album>();
    private int _nextId = 1;

    public int Add(Album albumModel)
    {
        albumModel.Id = _nextId++;
        _albums.Add(albumModel);
        return albumModel.Id;
    }

    public void Update(Album albumModel)
    {
        var existingAlbum = _albums.FirstOrDefault(a => a.Id == albumModel.Id);
        if (existingAlbum != null)
        {
            existingAlbum.Name = albumModel.Name;
            existingAlbum.Band = albumModel.Band;
            existingAlbum.SongList = albumModel.SongList;
            existingAlbum.ChartRanking = albumModel.ChartRanking;
            existingAlbum.ReleaseDate = albumModel.ReleaseDate;
            existingAlbum.Duration = albumModel.Duration;
        }
    }

    public void Delete(int id)
    {
        var albumToRemove = _albums.FirstOrDefault(a => a.Id == id);
        if (albumToRemove != null)
        {
            _albums.Remove(albumToRemove);
        }
    }

    public List<Album> FindAll()
    {
        return _albums.ToList();
    }

    public Album FindById(int id)
    {
        return _albums.FirstOrDefault(a => a.Id == id);
    }
}