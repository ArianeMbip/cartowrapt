using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class InterfaceUtilisateur
    {
        public InterfaceUtilisateur(string Nom, string Image) { 
            this.Nom = Nom;
            this.Image = Image;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("image")]
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
