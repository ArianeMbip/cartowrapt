using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Services;

public class ActifsService
{
    private readonly IMongoCollection<Actif> _actifsCollection;
    private readonly DAsService _dAsService;

    public ActifsService(
        IOptions<CartoDbSettings> cartoDbSettings,
        DAsService dAsService)
    {
        var mongoClient = new MongoClient(
            cartoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartoDbSettings.Value.DatabaseName);

        _actifsCollection = mongoDatabase.GetCollection<Actif>(
            cartoDbSettings.Value.ActifCollectionName);

        _dAsService = dAsService;
    }

    public async Task<List<Actif>> GetAsync() =>
        await _actifsCollection.Find(_ => true).ToListAsync();

    public async Task<Actif?> GetAsync(string id) =>
        await _actifsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //public async Task CreateAsync(Actif newActif) =>
    //    await _actifsCollection.InsertOneAsync(newActif);

    public async Task CreateAsync(Actif newActif)
    {
        await _actifsCollection.InsertOneAsync(newActif);

        // Créer le DA correspondant
        var newDA = new DA
        {
            // Initialisez les propriétés du DA en utilisant les valeurs appropriées
            // Utilisez les valeurs de newActif pour les propriétés correspondantes
            Nom = newActif.Nom + "_DA",
        };

        await _dAsService.CreateAsync(newDA);
    }

    public async Task UpdateAsync(string id, Actif updatedActif) =>
        await _actifsCollection.ReplaceOneAsync(x => x.Id == id, updatedActif);

    public async Task RemoveAsync(string id) =>
        await _actifsCollection.DeleteOneAsync(x => x.Id == id);
}
 