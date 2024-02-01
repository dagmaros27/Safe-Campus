using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SafeCampus.Models;
namespace SafeCampus.Services
{
    public class TrackService
    {
        private readonly IMongoCollection<Track> _trackCollection;

        public TrackService(IOptions<SafeCampusDatabaseSettings> safeCampusDatabaseSettings)
        {
            var mongoClient = new MongoClient(safeCampusDatabaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(safeCampusDatabaseSettings.Value.DatabaseName);
            _trackCollection =  mongoDb.GetCollection<Track>("Track");
        }

        public async Task<List<Track>> GetAllTracks()
        {
            return await _trackCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Track> GetTrackById(string id)
        {
            return await _trackCollection.Find(track => track.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateTrack(Track track)
        {
            await _trackCollection.InsertOneAsync(track);
        }

        public async Task UpdateTrack(string id, Track track)
        {
            await _trackCollection.ReplaceOneAsync(t => t.Id == id, track);
        }

        public async Task DeleteTrack(string id)
        {
            await _trackCollection.DeleteOneAsync(track => track.Id == id);
        }
    }
}
