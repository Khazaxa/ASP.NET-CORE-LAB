using Lab3zadanie.Models;
using Lab3___zadanieContextConnection.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class MemoryAlbumService : IAlbumService
    {
        private static readonly Dictionary<int, AlbumEntity> _albums = new Dictionary<int, AlbumEntity>();
        private static int albumId = 1;

        public int Add(AlbumEntity albumEntity)
        {
            albumEntity.AlbumId = albumId++;
            _albums.Add(albumEntity.AlbumId, albumEntity);
            return albumEntity.AlbumId;
        }

        public void Delete(int id)
        {
            _albums.Remove(id);
        }

        public List<AlbumEntity> FindAll()
        {
            return _albums.Values.ToList();
        }

        public AlbumEntity? FindById(int id)
        {
            _albums.TryGetValue(id, out var album);
            return album;
        }

        public void Update(AlbumEntity albumEntity)
        {
            if (_albums.ContainsKey(albumEntity.AlbumId))
            {
                _albums[albumEntity.AlbumId] = albumEntity;
            }
        }
    }
}
