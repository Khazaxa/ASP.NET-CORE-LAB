using AlbumData.Entities;

namespace Lab3zadanie.Models
{
    public static class SongMapper
    {
        public static SongEntity ToEntity(SongList song)
        {
            return new SongEntity
            {
                Id = song.Id,
                Title = song.Title,
                Duration = TimeSpan.FromMinutes(song.Duration),
                AlbumId = (int)song.AlbumId
            };
        }

        public static SongList FromEntity(SongEntity entity)
        {
            return new SongList
            {
                Id = entity.Id,
                Title = entity.Title,
                Duration = (int)entity.Duration.TotalMinutes,
                AlbumId = entity.AlbumId
            };
        }
    }

}
