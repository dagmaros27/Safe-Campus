using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SafeCampus.Models;

namespace  SafeCampus.Services;


public class LaptopService{

      private readonly IMongoCollection<Laptop> _laptopCollection;
    public LaptopService(IOptions<SafeCampusDatabaseSettings> safeCampusDatabaseSettings){

        var mongoClient = new MongoClient(safeCampusDatabaseSettings.Value.ConnectionString);
        var mongoDb = mongoClient.GetDatabase(safeCampusDatabaseSettings.Value.DatabaseName);
        _laptopCollection =  mongoDb.GetCollection<Laptop>("Laptop");
    }


    public async Task<List<Laptop>> GetAsync()
{
    var laptops = await _laptopCollection.Find(_ => true).ToListAsync();
    
    // Add debug information
    Console.WriteLine($"Number of laptops retrieved: {laptops.Count}");
    
    return laptops;
}

    public async Task<Laptop?> GetAsync(string id){
        return await _laptopCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

     public async Task CreateAsync(Laptop newLaptop) =>
        await _laptopCollection.InsertOneAsync(newLaptop);

    public async Task UpdateAsync(string id, Laptop updatedLaptop) =>
        await _laptopCollection.ReplaceOneAsync(x => x.Id == id, updatedLaptop);

    public async Task RemoveAsync(string id) =>
        await _laptopCollection.DeleteOneAsync(x => x.Id == id);

}



