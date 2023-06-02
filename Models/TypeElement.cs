using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Sieve.Attributes;

namespace CartoMongo.Models
{
    public class TypeElement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string? Nom { get; set; }

        [BsonElement("icone")]
        [JsonPropertyName("icone")]
        [BsonIgnoreIfNull]
        public string? Icone { get; set; } 

        [Required]
        [BsonElement("attributs")]
        [JsonPropertyName("attributs")]
        public List<Attribut>? Attribut { get; set; } 
    }
}
