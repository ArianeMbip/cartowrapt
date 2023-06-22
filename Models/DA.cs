using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class DA
    {
        public DA() 
         { }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        [BsonElement("nom")]
        [JsonPropertyName("nom")]
        public string Nom { get; set; }

        [Required]
        [BsonElement("contexte")]
        [JsonPropertyName("contexte")]
        public string Contexte { get; set; }

        [Required]
        [BsonElement("objectif")]
        [JsonPropertyName("objectif")]
        public string Objectif { get; set; }

        [Required]

        [BsonElement("statut")]
        [JsonPropertyName("statut")]
        public Statut Statut { get; set; }

        [Required]
        [BsonElement("domaineFonctionnel")]
        [JsonPropertyName("domaineFonctionnel")]
        public string DomaineFonctionnel { get; set; }

        [Required]
        [BsonElement("sousDomaineFonctionnel")]
        [JsonPropertyName("sousDomaineFonctionnel")]
        public string SousDomaineFonctionnel { get; set; }

        [Required]
        [BsonElement("fonction")]
        [JsonPropertyName("fonction")]
        public string Fonction { get; set; }

        [Required]
        [BsonElement("acteurs")]
        [JsonPropertyName("acteurs")]
        public string Acteurs { get; set; }

        [Required]
        [BsonElement("casUtilisation")]
        [JsonPropertyName("casUtilisation")]
        public string CasUtilisation { get; set; }

        [Required]
        [BsonElement("architectureFonctionnelle")]
        [JsonPropertyName("architectureFonctionnelle")]
        public string ArchitectureFonctionnelle { get; set; }

        //[Required]
        //[BsonElement("valeur")]
        //[JsonPropertyName("valeur")]
        //public string Actif { get; set; }

        [Required]
        [BsonElement("diagrammeSequence")]
        [JsonPropertyName("diagrammeSequence")]
        public string DiagrammeSequence { get; set; }

        [Required]
        [BsonElement("architectureApplicative")]
        [JsonPropertyName("architectureApplicative")]
        public string ArchitectureApplicative { get; set; }

        [Required]
        [BsonElement("architectureDonnees")]
        [JsonPropertyName("architectureDonnees")]
        public string ArchitectureDonnees { get; set; }

        [Required]
        [BsonElement("architectureTechnique")]
        [JsonPropertyName("architectureTechnique")]
        public string ArchitectureTechnique { get; set; }

        [Required]
        [BsonElement("historique")]
        [JsonPropertyName("historique")] 
        public Historique Historique { get; set; }

        [Required]
        [BsonElement("pieceJointe")]
        [JsonPropertyName("pieceJointe")]
        public PieceJointe PieceJointe { get; set; }

        [Required]
        [BsonElement("univers")]
        [JsonPropertyName("univers")]
        public Univers Univers { get; set; }

        [Required]
        [BsonElement("interfaceUtilisateur")]
        [JsonPropertyName("interfaceUtilisateur")]
        public InterfaceUtilisateur InterfaceUtilisateur { get; set; }

        [Required]
        [BsonElement("contact")]
        [JsonPropertyName("contact")]
        public Contact Contact { get; set; }

        [Required]
        [BsonElement("fonctionnalite")]
        [JsonPropertyName("fonctionnalite")]
        public Fonctionnalite Fonctionnalite { get; set; }

        [Required]
        [BsonElement("composant")]
        [JsonPropertyName("composant")]
        public Composant Composant { get; set; }


    }
}
