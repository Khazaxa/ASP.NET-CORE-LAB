using AlbumData.Entities;
using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3zadanie.Models
{
    public interface IAlbumService
    {
        int Add(Album album);
        void Delete(int id);
        void Update(Album album);
        List<Album> FindAll();
        Album? FindById(int id);
        List<SongEntity> GetSongs();
    }
}
