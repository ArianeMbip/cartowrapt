using CartoMongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using iText.Layout;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using iText.IO.Source;

namespace CartoMongo.Services;

//public interface IDAsService
//{
//    Task<byte[]> GeneratePdf();
//}

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

    public MemoryStream GeneratePdf(string filePath = "C:\\Users\\smart\\source\\repos\\testapi\\nom_de_votre_fichier.pdf")
    {
        var memoryStream = new MemoryStream();

        using (var writer = new PdfWriter(memoryStream))
        {
            using (var pdfDocument = new PdfDocument(writer))
            {
                using (var document = new Document(pdfDocument))
                {
                    // Votre code pour générer le contenu du PDF
                }
            }
        }

        memoryStream.Seek(0, SeekOrigin.Begin); // Réinitialiser la position du flux


        return memoryStream;
    }



    //public MemoryStream GeneratePdf(string filePath = "C:\\Users\\smart\\source\\repos\\testapi\\nom_de_votre_fichier.pdf")
    //public async Task<byte[]> GeneratePdf()
    //{
    //    // Récupérer les informations nécessaires des différentes entités
        //var daData = await _dAsCollection.Find(_ => true).ToListAsync();
    //    //var ContactData = await _dAsCollection.Find(_ => true).ToListAsync();
    //    //var fonctionnaliteData = await _dAsCollection.Find(_ => true).ToListAsync();
    //    //var InterfaceUtilisateurData = await _dAsCollection.Find(_ => true).ToListAsync();

    //    //public async Task<OtherEntity> GetOtherEntity(string id)
    //    //{
    //    //    return await _dbContext.OtherEntities.FindAsync(id);
    //    //}

    //    // Création du document PDF
        //using (var pdfWriter = new PdfWriter(filePath))
        //using (var pdfDocument = new PdfDocument(pdfWriter))
        //using (var document = new Document(pdfDocument)) {
        //    document.Close();
        //    return outputStream;
        //}
        //    {
        //        // Ajouter les informations récupérées au document
        //        Paragraph paragraph1 = new Paragraph($"Entity1 Info: {entity1Info.Property1}")
        //            .SetTextAlignment(TextAlignment.LEFT)
        //            .SetFontSize(12);

        //        Paragraph paragraph2 = new Paragraph($"Entity2 Info: {entity2Info.Property2}")
        //            .SetTextAlignment(TextAlignment.LEFT)
        //            .SetFontSize(12);

        //        document.Add(paragraph1);
        //        document.Add(paragraph2);

        //        // ...
        //    }
        // Enregistrement du document PDF dans un MemoryStream
            
    //}

    //public MemoryStream GeneratePdf()
    //{
    //    // Requête pour récupérer les données
    //    var filter = Builders<BsonDocument>.Filter.Empty.ToBson();
    //    var projection = Builders<BsonDocument>.Projection.Exclude("_id"); // Exclusion de l'identifiant MongoDB
    //    var result = _dAsCollection.Find((_ => true)).Project(projection).ToList();

    //    // Création d'un nouveau document PDF
    //    var outputStream = new MemoryStream();
    //    var writer = new PdfWriter(outputStream);
    //    var pdfDocument = new PdfDocument(writer);
    //    var document = new Document(pdfDocument);

    //    // Ajout des données récupérées au document PDF
    //    foreach (var item in result)
    //    {
    //        document.Add(new Paragraph(item["nom_de_votre_champ"].ToString())); // Ajout d'un paragraphe contenant les données d'un champ
    //    }

    //    // Enregistrement du document PDF dans un MemoryStream
    //    document.Close();
    //    return outputStream;
    //}

    //public async Task<byte[]> GeneratePdf()
    //{
    //    var filter = Builders<BsonDocument>.Filter.Empty.ToBson();

    //    var daDocuments = await _dAsCollection.Find(_ => true).ToListAsync();

    //    var memoryStream = new MemoryStream();

    //    using (var writer = new PdfWriter(memoryStream))
    //    {
    //        using (var pdfDocument = new PdfDocument(writer))
    //        {
    //            using (var document = new Document(pdfDocument))
    //            {
    //                foreach (var dbDocument in daDocuments)
    //                {
    //                    // Ajouter les données à votre document PDF
    //                    document.Add(new Paragraph(dbDocument.Objectif));
    //                }
    //            }
    //        }
    //    }

    //    // Convertir le MemoryStream en tableau de bytes
    //    var pdfBytes = memoryStream.ToArray();

    //    return pdfBytes;
    //}

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
