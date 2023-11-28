using AlbumData.Entities;
using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class AlbumMapper
    {
        public static AlbumEntity ToEntity(Album model)
        {
            return new AlbumEntity()
            {
                AlbumId = model.Id, // Może być usunięte, jeśli baza danych generuje ID automatycznie
                Title = model.Title,
                Band = model.Artist,
                ChartPosition = model.ChartPosition.ToString(),
                ReleaseYear = model.ReleaseYear,
                Duration = TimeSpan.FromMinutes(model.Duration),
                Genre = model.Genre,
                // Songs - jeśli chcesz je mapować, trzeba przekształcić SongList na ICollection<SongEntity>
            };
        }

        public static Album FromEntity(AlbumEntity entity)
        {
            return new Album()
            {
                Id = entity.AlbumId,
                Title = entity.Title,
                Artist = entity.Band,
                ChartPosition = entity.ChartPosition,
                ReleaseYear = entity.ReleaseYear,
                Duration = (int)(entity.Duration?.TotalMinutes ?? 0),
                Genre = entity.Genre,
                // SongList - jeśli chcesz je mapować, trzeba przekształcić Songs na List<SelectListItem>
            };
        }
    }
}
