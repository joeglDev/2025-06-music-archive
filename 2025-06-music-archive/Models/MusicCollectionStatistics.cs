namespace _2025_06_music_archive.Models;

public record MusicCollectionStatistics(
    string[] UniqueArtists,
    string[] UniqueGenres,
    int ArtistsCount,
    int GenresCount
    );