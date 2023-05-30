using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Services;

public class DAsService
{
    private readonly IMongoCollection<DA> _dAsCollection;

    public DAsService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _dAsCollection = mongoDatabase.GetCollection<DA>(
            cartoDbSettings.Value.DACollectionName);
    }

    public async Task<List<DA>> GetAsync() =>
        await _dAsCollection.Find(_ => true).ToListAsync();

    public async Task<DA?> GetAsync(string id) =>
        await _dAsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(DA newDA) =>
        await _dAsCollection.InsertOneAsync(newDA);

    public async Task UpdateAsync(string id, DA updatedDA) =>
        await _dAsCollection.ReplaceOneAsync(x => x.Id == id, updatedDA);

    public async Task RemoveAsync(string id) =>
        await _dAsCollection.DeleteOneAsync(x => x.Id == id);
}
