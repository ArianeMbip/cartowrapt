using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Environnement
    {
        public Environnement(string Nom) {
            this.Nom = Nom;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }
    }
}
