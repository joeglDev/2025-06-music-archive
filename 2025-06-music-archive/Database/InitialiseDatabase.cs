using _2025_06_music_archive.utils;
using Npgsql;

namespace _2025_06_music_archive.Database;

public abstract class InitialiseDatabase
{
    public NpgsqlConnection? Connection;

    private static Dictionary<string, string?> GetEnvVariables()
    {
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, "../../../utils/.env");
        DotEnv.Load(dotenv);

        var envVars = new Dictionary<string, string?>
        {
            ["HOST"] = Environment.GetEnvironmentVariable("HOST"),
            ["DATABASE"] = Environment.GetEnvironmentVariable("DATABASE"),
            ["USERNAME"] = Environment.GetEnvironmentVariable("USERNAME"),
            ["PASSWORD"] = Environment.GetEnvironmentVariable("PASSWORD")
        };

        return envVars;
    }

    public NpgsqlConnection GetIndividualConnection()
    {
        Console.WriteLine("Setting the connection string");

        var envVars = GetEnvVariables();

        var connectionString =
            $"Host={envVars["HOST"]};database={envVars["DATABASE"]};Username={envVars["USERNAME"]};Password={envVars["PASSWORD"]};";

        var connection = new NpgsqlConnection(connectionString);
        return connection;
    }
}