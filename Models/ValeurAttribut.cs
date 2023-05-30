using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    [BsonIgnoreExtraElements]
    public class ValeurAttribut
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string Valeur { get; set; }

        [Required]
        [BsonElement("attribut")]
        [JsonPropertyName("attribut")]
        public Attribut Attribut { get; set; }

        [Required]
        [BsonElement("environnement")]
        [JsonPropertyName("environnement")]
        public Environnement Environnement { get; set; }


    }
}
