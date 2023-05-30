using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Personne
    {
        public Personne(string Nom, string CUID, Role Role) { 
            this.Nom = Nom;
            this.CUID = CUID;
            this.Role = Role;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("CUID")]
        [JsonPropertyName("CUID")]
        public string CUID { get; set; }

        [Required]
        [BsonElement("role")]
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
