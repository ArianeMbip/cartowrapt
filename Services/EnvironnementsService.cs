using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Hosting;

namespace CartoMongo.Services;

public class EnvironnementsService
{
    private readonly IMongoCollection<Environnement> _environnementsCollection;

    public EnvironnementsService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _environnementsCollection = mongoDatabase.GetCollection<Environnement>(
            cartoDbSettings.Value.EnvironnementCollectionName);
    }

    public async Task<List<Environnement>> GetAsync() =>
        await _environnementsCollection.Find(_ => true).ToListAsync();

    public async Task<Environnement?> GetAsync(string id) =>
        await _environnementsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Environnement newEnvironnement) =>
        await _environnementsCollection.InsertOneAsync(newEnvironnement);

    public async Task UpdateAsync(string id, Environnement updatedEnvironnement) =>
        await _environnementsCollection.ReplaceOneAsync(x => x.Id == id, updatedEnvironnement);

    public async Task RemoveAsync(string id) =>
        await _environnementsCollection.DeleteOneAsync(x => x.Id == id);
}
