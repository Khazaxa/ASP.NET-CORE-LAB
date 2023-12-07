using Lab3___zadanieContextConnection.Entities;

namespace Lab3zadanie.Models
{
    public interface IAlbumService
    {
        int Add(AlbumEntity albumEntity);
        void Update(AlbumEntity albumEntity);
        void Delete(int id);
        AlbumEntity? FindById(int id);
        List<AlbumEntity> FindAll();
    }
}
