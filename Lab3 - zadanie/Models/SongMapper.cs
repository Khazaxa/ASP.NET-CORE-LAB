using AlbumData.Entities;

namespace Lab3zadanie.Models
{
    public static class SongMapper
    {
        public static SongEntity ToEntity(Song song)
        {
            return new SongEntity
            {
                Id = song.Id,
                Title = song.Title,
                Duration = song.Duration,
                AlbumId = (int)song.AlbumId
            };
        }

        public static Song FromEntity(SongEntity entity)
        {
            return new Song
            {
                Id = entity.Id,
                Title = entity.Title,
                Duration = entity.Duration,
                AlbumId = entity.AlbumId
            };
        }
    }

}
