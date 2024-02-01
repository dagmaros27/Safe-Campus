using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SafeCampus.Models;

namespace SafeCampus.Services
{
    public class ReportService
    {
        private readonly IMongoCollection<Report> _reportCollection;

         public ReportService(IOptions<SafeCampusDatabaseSettings> safeCampusDatabaseSettings){

        var mongoClient = new MongoClient(safeCampusDatabaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(safeCampusDatabaseSettings.Value.DatabaseName);
        _reportCollection =  mongoDb.GetCollection<Report>("Report");
    }

        public async Task<List<Report>> GetAllReports()
        {
            return await _reportCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Report> GetReportById(string id)
        {
            return await _reportCollection.Find(report => report.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateReport(Report report)
        {
            await _reportCollection.InsertOneAsync(report);
        }

        public async Task UpdateReport(string id, Report report)
        {
            await _reportCollection.ReplaceOneAsync(r => r.Id == id, report);
        }

        public async Task DeleteReport(string id)
        {
            await _reportCollection.DeleteOneAsync(report => report.Id == id);
        }
    }
}
