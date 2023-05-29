using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Services;

public class FluxService
{
    private readonly IMongoCollection<Flux> _fluxCollection;

    public FluxService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _fluxCollection = mongoDatabase.GetCollection<Flux>(
            cartoDbSettings.Value.FluxCollectionName);
    }

    public async Task<List<Flux>> GetAsync() =>
        await _fluxCollection.Find(_ => true).ToListAsync();

    public async Task<Flux?> GetAsync(string id) =>
        await _fluxCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Flux newFlux) =>
        await _fluxCollection.InsertOneAsync(newFlux);

    public async Task UpdateAsync(string id, Flux updatedFlux) =>
        await _fluxCollection.ReplaceOneAsync(x => x.Id == id, updatedFlux);

    public async Task RemoveAsync(string id) =>
        await _fluxCollection.DeleteOneAsync(x => x.Id == id);
}
