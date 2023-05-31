using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Composant
    {
        public Composant(string Nom, TypeElement TypeComposant) {
            this.Nom = Nom;
            this.TypeComposant = TypeComposant;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("typeComposant")]
        [JsonPropertyName("typeComposant")]
        public TypeElement TypeComposant { get; set; }

        [BsonElement("valeurAttribut")]
        [JsonPropertyName("valeurAttribut")]
        public virtual List<ValeurAttribut>? ValeurAttribut { get; set; }

    }
}
