using _2025_06_music_archive.utils;
using Dapper;
using Npgsql;

namespace _2025_06_music_archive.Database;

public class DatabaseSeeder : InitialiseDatabase
{
    public async Task SeedDatabase()
    {
        var conn = GetIndividualConnection();

        await CreateTable(conn);
        await PopulateTable(conn);
    }

    private async Task CreateTable(NpgsqlConnection conn)
    {
        Console.WriteLine("Creating tables...");
        var createTableQuery = @"CREATE TABLE IF NOT EXISTS albums (
    Catalog VARCHAR(50),
    Artist TEXT,
    Title TEXT,
    Label VARCHAR(50),
    Format VARCHAR(50),
    Rating VARCHAR(50),
    Released INTEGER,
    ReleaseId TEXT,
    CollectionFolder VARCHAR(50),
    DateAdded TIMESTAMP,
    MediaCondition VARCHAR(50),
    sleeveCondition VARCHAR(50),
    Owner VARCHAR(50),
    Genre VARCHAR(50)
);";

        await conn.ExecuteAsync(createTableQuery);
    }

    private async Task PopulateTable(NpgsqlConnection conn)
    {
        Console.WriteLine("Populating tables...");

        var csvPath = Directory.GetCurrentDirectory() + "/../../../Database/data/seed-data.csv";

        var fileIoLogic = new FileIoLogic();
        var csvData = fileIoLogic.ReadCsvFile(csvPath);
        var albumRows = fileIoLogic.ConvertRowsToAlbumRows(csvData);

        var insertDataSql = @"
        INSERT INTO albums (
    catalog, artist, title, label, format, rating,
    released, releaseId, collectionFolder, dateAdded,
    mediaCondition, sleeveCondition, owner, genre
    )
        SELECT 
    @catalog, @artist, @title, @label, @Format, @rating,
    @released, @releaseId, @collectionFolder, @dateAdded,
    @MediaCondition, @sleeveCondition, @owner, @Genre
        WHERE NOT EXISTS (
            SELECT 1 FROM albums WHERE title = @title
                );";

        await conn.ExecuteAsync(insertDataSql, albumRows);
    }
}