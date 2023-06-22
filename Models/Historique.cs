using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class Historique
    {
        public Historique(string Nom, string PartieModifiee, string NomUtilisateur, string CUID, DateTime DateModification) { 
            this.Nom = Nom;
            this.PartieModifiee = PartieModifiee;

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("dateModification")]
        [JsonPropertyName("dateModification")]
        public DateTime DateModification { get; set; }

        [Required]
        [BsonElement("partieModifiee")]
        [JsonPropertyName("partieModifiee")]
        public string PartieModifiee { get; set; }

        [Required]
        [BsonElement("CUID")]
        [JsonPropertyName("CUID")]
        public string CUID { get; set; }

        [Required]
        [BsonElement("nomUtilisateur")]
        [JsonPropertyName("nomUtilisateur")]
        public string NomUtilisateur { get; set; }

    }
}
