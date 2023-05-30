using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Services;

public class TypeElementsService
{
    private readonly IMongoCollection<TypeElement> _typeElementsCollection;

    public TypeElementsService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _typeElementsCollection = mongoDatabase.GetCollection<TypeElement>(
            cartoDbSettings.Value.TypeElementCollectionName);
    }

    public async Task<List<TypeElement>> GetAsync() =>
        await _typeElementsCollection.Find(_ => true).ToListAsync();

    public async Task<TypeElement?> GetAsync(string id) =>
        await _typeElementsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TypeElement newTypeElement) =>
        await _typeElementsCollection.InsertOneAsync(newTypeElement);

    public async Task UpdateAsync(string id, TypeElement updatedTypeElement) =>
        await _typeElementsCollection.ReplaceOneAsync(x => x.Id == id, updatedTypeElement);

    public async Task RemoveAsync(string id) =>
        await _typeElementsCollection.DeleteOneAsync(x => x.Id == id);

    internal Task GetAsync(TypeElement typeActif)
    {
        throw new NotImplementedException();
    }
}
