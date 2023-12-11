using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Models;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class AlbumMapper
    {
        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                AlbumId = model.AlbumId,
                Title = model.Title,
                Band = model.Band,
                ChartPosition = model.ChartPosition,
                ReleaseYear = model.ReleaseYear,
                Duration = model.Duration,
                Genre = model.Genre,
                Songs = model.Songs?.Select(s => SongMapper.ToEntity(s)).ToList()
            };
        }

        public static Album FromEntity(AlbumEntity entity)
        {
            return new Album()
            {
                AlbumId = entity.AlbumId,
                Title = entity.Title,
                Band = entity.Band,
                ChartPosition = entity.ChartPosition,
                ReleaseYear = entity.ReleaseYear,
                Duration = entity.Duration,
                Genre = entity.Genre,
                Songs = entity.Songs?.Select(s => SongMapper.FromEntity(s)).ToList()
            };
        }

        internal static object FromEntity(Album albumEntity)
        {
            throw new NotImplementedException();
        }
    }
}
