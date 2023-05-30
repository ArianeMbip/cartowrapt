using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Drawing;

namespace CartoMongo.Services;

public class IconesService
{
    private readonly IMongoCollection<Icone> _iconesCollection;

    public IconesService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _iconesCollection = mongoDatabase.GetCollection<Icone>(
            cartoDbSettings.Value.IconeCollectionName);
    }

    public async Task<List<Icone>> GetAsync() =>
        await _iconesCollection.Find(_ => true).ToListAsync();

    public async Task<Icone?> GetAsync(string id) =>
        await _iconesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Icone newIcone) =>
        await _iconesCollection.InsertOneAsync(newIcone);

    public async Task UpdateAsync(string id, Icone updatedIcone) =>
        await _iconesCollection.ReplaceOneAsync(x => x.Id == id, updatedIcone);

    public async Task RemoveAsync(string id) =>
        await _iconesCollection.DeleteOneAsync(x => x.Id == id);
}
