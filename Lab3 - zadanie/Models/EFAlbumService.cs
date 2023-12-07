using Lab3___zadanieContextConnection;
using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class EFAlbumService : IAlbumService
    {
        private readonly AppDbContext _context;
        public EFAlbumService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public int Add(AlbumEntity albumEntity)
        {
            var e = _context.Albums.Add(albumEntity);
            _context.SaveChanges();
            return e.Entity.AlbumId;
        }

        public void Delete(int id)
        {
            var album = _context.Albums.Find(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }

        public List<AlbumEntity> FindAll()
        {
            return _context.Albums
                           .Include(a => a.Songs)
                           .ToList();
        }

        public AlbumEntity? FindById(int id)
        {
            return _context.Albums
                                .Include(a => a.Songs)
                                .FirstOrDefault(a => a.AlbumId == id);
        }

        public void Update(AlbumEntity albumEntity)
        {
            var existingAlbum = _context.Albums.Find(albumEntity.AlbumId);
            if (existingAlbum != null)
            {
                _context.Entry(existingAlbum).CurrentValues.SetValues(albumEntity);
                _context.SaveChanges();
            }
        }

        public void AddSong(Song song)
        {
            if (song.AlbumId <= 0)
            {
                throw new InvalidOperationException("Song must have a valid AlbumId");
            }

            var songEntity = SongMapper.ToEntity(song);
            _context.Songs.Add(songEntity);
            _context.SaveChanges();
        }
    }
}
