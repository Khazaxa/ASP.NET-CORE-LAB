using System.Collections.Generic;
using System.Linq;
using lab3b.Models;
using AlbumData;
using AlbumData.Entities;

namespace lab3b.Models;

public class EFAlbumService : IAlbumService
{
    private readonly AlbumDbContext _context;

    public EFAlbumService(AlbumDbContext context)
    {
        _context = context;
    }

    public int Add(Album album)
    {
        album = AlbumMapper.ToModel(album);
        _context.Albums.Add(album);
        _context.SaveChanges();
        return album.Id;
    }

    public void Delete(int id)
    {
        var album = _context.Albums.FirstOrDefault(a => a.Id == id);
        if (album != null)
        {
            _context.Albums.Remove(album);
            _context.SaveChanges();
        }
    }

    public List<Album> FindAll()
    {
        return _context.Albums.Select(a => AlbumMapper.ToViewModel(a)).ToList();
    }

    public Album FindById(int id)
    {
        var album = _context.Albums.FirstOrDefault(a => a.Id == id);
        return album != null ? AlbumMapper.ToModel(album) : null;
    }
    
    public void Update(Album album)
    {
        album = AlbumMapper.ToModel(album);
        _context.Albums.Update(album);
        _context.SaveChanges();
    }
}