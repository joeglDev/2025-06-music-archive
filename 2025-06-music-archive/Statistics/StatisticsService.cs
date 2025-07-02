using _2025_06_music_archive.Models;

namespace _2025_06_music_archive.Statistics;

public class StatisticsService(AlbumRow[] albums)
{
    private AlbumRow[] _albums = albums;

    public void GetStatistics()
    {
        var (artistsCount, uniqueArtists) = GetAllArtists();
        
        Console.WriteLine($"Number of artists: {artistsCount}");
        Console.WriteLine($"Unique artists: {string.Join(", ", uniqueArtists)}");
    }

    private (int, string[]) GetAllArtists()
    {
        var artistsCount = _albums.Select(x => x.Artist).Distinct().Count();
        var uniqueArtists = _albums.Select(x => x.Artist).Distinct().ToArray();

        return (artistsCount, uniqueArtists);
    }
}