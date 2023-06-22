using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public enum Type
    {
        ExigeanceFonctionnelle,
        ExigeanceNonFonctionnelle
    }

    public class Fonctionnalite
    {
        public Fonctionnalite(string Nom, Type Type) { 
            this.Nom = Nom;
            this.Type = Type;
        }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("type")]
        [JsonPropertyName("type")]
        public Type Type { get; set; }
    }
}
