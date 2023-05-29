using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Services;

public class ActifsService
{
    private readonly IMongoCollection<Actif> _actifsCollection;

    public ActifsService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _actifsCollection = mongoDatabase.GetCollection<Actif>(
            cartoDbSettings.Value.ActifCollectionName);
    }

    public async Task<List<Actif>> GetAsync() =>
        await _actifsCollection.Find(_ => true).ToListAsync();

    public async Task<Actif?> GetAsync(string id) =>
        await _actifsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Actif newActif) =>
        await _actifsCollection.InsertOneAsync(newActif);

    public async Task UpdateAsync(string id, Actif updatedActif) =>
        await _actifsCollection.ReplaceOneAsync(x => x.Id == id, updatedActif);

    public async Task RemoveAsync(string id) =>
        await _actifsCollection.DeleteOneAsync(x => x.Id == id);
}
