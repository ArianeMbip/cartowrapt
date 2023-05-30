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
<<<<<<< HEAD
        public String? Id { get; set; }
=======
        public string? Id { get; set; }
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string? Nom { get; set; }

        [BsonElement("icone")]
        [JsonPropertyName("icone")]
        public string? Icone { get; set; } 

        [Required]
        [BsonElement("attributs")]
        [JsonPropertyName("attributs")]
        public List<Attribut>? Attribut { get; set; } 
    }
}
