using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Contact
    {
        public Contact(string Email, string Nom, string Fonction, string Entite, string Telephone) {
            this.Email = Email; 
            this.Nom = Nom; 
            this.Fonction = Fonction; 
            this.Entite = Entite;
            this.Telephone = Telephone;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [BsonElement("entite")]
        [JsonPropertyName("entite")]
        public string Entite { get; set; }

        [Required]
        [BsonElement("fonction")]
        [JsonPropertyName("fonction")]
        public string Fonction { get; set; }

        [Required]
        [BsonElement("telephone")]
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

    }
}
