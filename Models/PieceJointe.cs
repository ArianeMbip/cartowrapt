using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class PieceJointe
    {
        public PieceJointe(string Nom, string Chemin) { 
            this.Nom = Nom;
            this.Chemin = Chemin;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("chemin")]
        [JsonPropertyName("chemin")]
        public string Chemin { get; set; }

        
    }
}
