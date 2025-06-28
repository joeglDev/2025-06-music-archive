namespace _2025_06_music_archive.Models;

public record AlbumRow(
    string catalog,
    string artist,
    string title,
    string recordLabel,
    string Format,
    string rating,
    int? releaseYear,
    string releaseId,
    string collectionFolder,
    DateTime? dateAdded,
    string MediaCondition,
    string sleeveCondition,
    string owner,
    string Genre
);