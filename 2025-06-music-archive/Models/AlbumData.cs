namespace _2025_06_music_archive.Models;

public record AlbumRow(
    string Catalog,
    string Artist,
    string Title,
    string Label,
    string Format,
    string Rating,
    int? Released,
    string ReleaseId,
    string CollectionFolder,
    DateTime? DateAdded,
    string MediaCondition,
    string SleeveCondition,
    string Owner,
    string Genre
);