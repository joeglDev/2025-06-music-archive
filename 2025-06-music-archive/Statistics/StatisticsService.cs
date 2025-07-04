using _2025_06_music_archive.Models;

namespace _2025_06_music_archive.Statistics;

public class StatisticsService(AlbumRow[] albums)
{
    private AlbumRow[] _albums = albums;

    public MusicCollectionStatistics GetStatistics()
    {
        // artists
        var (artistsCount, uniqueArtists) = GetAllArtists();
        
        Console.WriteLine($"Number of artists: {artistsCount}");
        Console.WriteLine($"Unique artists: {string.Join(", ", uniqueArtists)}");
        
        // genres
        var (genresCount, uniqueGenres) = GetAllGenres();
        
        Console.WriteLine($"Number of genres: {genresCount}");
        Console.WriteLine($"Unique genres: {string.Join(", ", uniqueGenres)}");

        return new MusicCollectionStatistics(uniqueArtists, uniqueGenres, artistsCount, genresCount);
    }

    private (int, string[]) GetAllArtists()
    {
        var artistsCount = _albums.Select(x => x.Artist).Distinct().Count();
        var uniqueArtists = _albums.Select(x => x.Artist).Distinct().ToArray();

        return (artistsCount, uniqueArtists);
    }

    private (int, string[]) GetAllGenres()
    {
        var genreCount = _albums.Select(x => x.Genre).Distinct().Count();
        var uniqueGenres = _albums.Select(x => x.Genre).Distinct().ToArray();
        
        return (genreCount, uniqueGenres);
    }
}