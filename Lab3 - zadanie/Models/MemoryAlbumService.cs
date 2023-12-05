using AlbumData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3zadanie.Models
{
    public class MemoryAlbumService : IAlbumService
    {
        static readonly Dictionary<int, Album> _albums = new Dictionary<int, Album>();
        static readonly Dictionary<int, SongList> _songs = new Dictionary<int, SongList>();
        static int id = 1;
        static int songId = 1;

        public int Add(Album album)
        {
            int id = _albums.Keys.Count != 0 ? _albums.Keys.Max() : 0;
            album.Id = id + 1;
            _albums.Add(album.Id, album);
            return album.Id;
        }

        public void Delete(int id)
        {
            _albums.Remove(id);
        }

        public List<Album> FindAll()
        {
            return _albums.Values.ToList();
        }

        public Album? FindById(int id)
        {
            _albums.TryGetValue(id, out var album);
            return album;
        }

        public void Update(Album album)
        {
            if (_albums.ContainsKey(album.Id))
            {
                _albums[album.Id] = album;
            }
        }

        public void AddSong(SongList song)
        {
            song.Id = songId++;
            _songs.Add(song.Id, song);
        }
    }
}
