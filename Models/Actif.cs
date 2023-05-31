using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Sieve.Attributes;

namespace CartoMongo.Models
{
    public enum Criticite
    {
        Basse,
        Moyenne,
        Haute,
        Critique
    }
    public enum Statut
    {
        Brouillon,
        Valide,
        Decommissionne
    }

    public class Actif

    {
        public Actif(TypeElement TypeActif, string Nom, string Description, string Version, Statut Statut) {
            this.Nom = Nom;
            this.Description = Description;
            this.Version = Version;
            this.Statut = Statut;
            this.TypeActif = TypeActif;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        [Sieve(CanFilter = true, CanSort = true)]
        public string Nom { get; set; }

        [BsonElement("criticite")]
        [JsonPropertyName("criticite")]
        [BsonIgnoreIfNull]
        public Criticite? Criticite { get; set; }

        [Required]
        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required] 
        [BsonElement("version")]
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [BsonElement("icone")]
        [JsonPropertyName("icone")]
        public string? Icone { get; set; }

        [Required]
        [BsonElement("statut")]
        [JsonPropertyName("statut")]
        public Statut Statut { get; set; }

        [Required]
        [BsonElement("typeActif")]
        [JsonPropertyName("typeActif")]
        public TypeElement TypeActif { get; set; }

        [BsonElement("preVersion")]
        [JsonPropertyName("preVersion")]
        public Actif? PreVersion { get; set; }

        [BsonElement("hierarchie")]
        [JsonPropertyName("hierarchie")]
        public Actif? Hierarchie { get; set; }

        [BsonElement("personne")]
        [JsonPropertyName("personne")]
        public List<Personne>? Personne { get; set; }

        [BsonElement("valeurAttribut")]
        [JsonPropertyName("valeurAttribut")]
        public List<ValeurAttribut>? ValeurAttribut { get; set; }

    }
}
