using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("requis")]
        [JsonPropertyName("statut")]
        public bool Lire { get; set; }

        [Required]
        [BsonElement("ecrire")]
        [JsonPropertyName("ecrire")]
        public bool Ecrire { get; set; }

        [Required]
        [BsonElement("modifier")]
        [JsonPropertyName("modifier")]
        public bool Modifier { get; set; }

        [Required]
        [BsonElement("supprimer")]
        [JsonPropertyName("supprimer")]
        public bool Supprimer { get; set; }

        [Required]
        [BsonElement("valider")]
        [JsonPropertyName("valider")]
        public bool Valider { get; set; }

        [Required]
        [BsonElement("archiver")]
        [JsonPropertyName("archiver")]
        public bool Archiver { get; set; }

        [Required]
        [BsonElement("generer")]
        [JsonPropertyName("generer")]
        public bool Generer { get; set; }

    }
}
