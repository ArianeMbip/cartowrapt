using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Flux
    {
        public Flux(string Nom) { 
            this.Nom = Nom;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("entree")]
        [JsonPropertyName("entree")]
        public Actif Entree { get; set; }

        [BsonElement("sortie")]
        [JsonPropertyName("sortie")]
        public Actif? Sortie { get; set; }


        [Required]
        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [BsonElement("typeFlux")]
        [JsonPropertyName("typeFlux")]
        public TypeElement TypeFlux { get; set; }

        [BsonElement("valeurAttribut")]
        [JsonPropertyName("valeurAttribut")]
        public virtual List<ValeurAttribut>? ValeurAttribut { get; set; }

    }
}
