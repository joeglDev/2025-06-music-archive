// See https://aka.ms/new-console-template for more information

using _2025_06_music_archive.Database;
using _2025_06_music_archive.Statistics;

// seed database
var dbSeeder = new DatabaseSeeder();
await dbSeeder.SeedDatabase();

// get all albums from database
var dbService = new DatabaseService();
var allAlbums = await dbService.SelectAllAlbums();

// generate statistics
var statisticsService = new StatisticsService(allAlbums);
var collectionStatistics = statisticsService.GetStatistics();

// save statistics to a text file