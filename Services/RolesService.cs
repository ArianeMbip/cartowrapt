using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data;

namespace CartoMongo.Services;

public class RolesService
{
    private readonly IMongoCollection<Role> _rolesCollection;

    public RolesService(
        IOptions<CartoDbSettings> cartoDbSettings)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _rolesCollection = mongoDatabase.GetCollection<Role>(
            cartoDbSettings.Value.RoleCollectionName);
    }

    public async Task<List<Role>> GetAsync() =>
        await _rolesCollection.Find(_ => true).ToListAsync();

    public async Task<Role?> GetAsync(string id) =>
        await _rolesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Role newRole) =>
        await _rolesCollection.InsertOneAsync(newRole);

    public async Task UpdateAsync(string id, Role updatedRole) =>
        await _rolesCollection.ReplaceOneAsync(x => x.Id == id, updatedRole);

    public async Task RemoveAsync(string id) =>
        await _rolesCollection.DeleteOneAsync(x => x.Id == id);
}
