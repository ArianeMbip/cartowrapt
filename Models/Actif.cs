using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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
<<<<<<< HEAD
        public Actif(string Nom, string Description, string Version, string Statut) {
=======
        public Actif(TypeElement TypeActif, string Nom, string Description, string Version, string Statut) {
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915
            this.Nom = Nom;
            this.Description = Description;
            this.Version = Version;
            this.Statut = Statut;
<<<<<<< HEAD
=======
            this.TypeActif = TypeActif;
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [BsonElement("criticite")]
        [JsonPropertyName("criticite")]
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
        public string Statut { get; set; }

        [Required]
        [BsonElement("typeActif")]
        [JsonPropertyName("typeActif")]
<<<<<<< HEAD
        public TypeElement? TypeActif { get; set; }
=======
        public TypeElement TypeActif { get; set; }
>>>>>>> bdb7a1ac6a2bb452098173ce94631ecb80a4f915

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
