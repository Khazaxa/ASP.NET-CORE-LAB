using AlbumData.Entities;
using Lab3zadanie.Models;

namespace Lab3zadanie.Models
{
    public class AlbumMapper
    {
        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                AlbumId = model.Id,
                Title = model.Title,
                Band = model.Artist,
                ReleaseYear = model.ReleaseYear,
                Genre = model.Genre
            };
        }

        public static Album FromEntity(AlbumEntity entity)
        {
            return new Album()
            {
                Id = entity.AlbumId,
                Title = entity.Title,
                Artist = entity.Band,
                ReleaseYear = entity.ReleaseYear,
                Genre = entity.Genre
            };
        }
    }
}
