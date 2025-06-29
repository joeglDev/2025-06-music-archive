using _2025_06_music_archive.Models;
using Dapper;

namespace _2025_06_music_archive.Database;

public class DatabaseService : InitialiseDatabase
{
    public async Task<AlbumRow[]> SelectAllAlbums()
    {
        var conn = GetIndividualConnection();
        var sql = "SELECT * FROM albums";
        var albumRowsFromDb = await conn.QueryAsync<AlbumRow>(sql);

        return albumRowsFromDb.ToArray();
    }
}