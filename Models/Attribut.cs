using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Attribut
    {
        public Attribut(string Nom, bool Requis, string TypeDonnee) { 
            this.Nom = Nom;
            this.Requis = Requis;
            this.TypeDonnee = TypeDonnee;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("requis")]
        [JsonPropertyName("requis")]
        public bool Requis { get; set; }

        [Required]
        [BsonElement("typeDonnee")]
        [JsonPropertyName("typeDonnee")]
        public string TypeDonnee { get; set; }

    }
}
