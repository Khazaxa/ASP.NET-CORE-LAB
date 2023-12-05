using AlbumData;
using AlbumData.Entities;
using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3zadanie.Models
{
    public class EFAlbumService : IAlbumService
    {
        private readonly AppDbContext _context;
        public EFAlbumService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public int Add(Album album)
        {
            var e = _context.Albums.Add(AlbumMapper.ToEntity(album));
            _context.SaveChanges();
            int id = e.Entity.AlbumId; 
            return id;
        }

        public void Delete(int id)
        {
            AlbumEntity? find = _context.Albums.Find(id); 
            if (find != null)
            {
                _context.Albums.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Album> FindAll()
        {
            return _context.Albums.Select(e => AlbumMapper.FromEntity(e)).ToList();
        }

        public Album? FindById(int id)
        {
            AlbumEntity? find = _context.Albums.Find(id);
            return find != null ? AlbumMapper.FromEntity(find) : null;
        }

        public void Update(Album album)
        {
            _context.Albums.Update(AlbumMapper.ToEntity(album));
            _context.SaveChanges();
        }

        public void AddSong(SongList song)
        {
            var songEntity = SongMapper.ToEntity(song);
            _context.Songs.Add(songEntity);
            _context.SaveChanges();
        }

    }
}
