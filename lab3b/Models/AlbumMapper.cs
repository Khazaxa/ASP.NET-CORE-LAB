using lab3b.Models;

namespace lab3b.Models;

public static class AlbumMapper
{
    public static Album ToViewModel(Album album)
    {
        return new Album
        {
            Id = album.Id,
            Name = album.Name,
            Band = album.Band,
            SongList = album.SongList,
            ChartRanking = album.ChartRanking,
            ReleaseDate = album.ReleaseDate,
            Duration = album.Duration
        };
    }

    public static Album ToModel(Album viewModel)
    {
        return new Album
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Band = viewModel.Band,
            SongList = viewModel.SongList,
            ChartRanking = viewModel.ChartRanking,
            ReleaseDate = viewModel.ReleaseDate,
            Duration = viewModel.Duration
        };
    }
}