using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CartoMongo.Models
{
    public class DA
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required]
        [BsonElement("contexte")]
        [JsonPropertyName("contexte")]
        public string Contexte { get; set; }

        [Required]
        [BsonElement("objectif")]
        [JsonPropertyName("objectif")]
        public string Objectif { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public Statut Statut { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string DomaineFonctionnel { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string SousDomaineFonctionnel { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string Fonction { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string Acteurs { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string CasUtilisation { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string ArchitectureFonctionnelle { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string Actif { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string DiagrammeSequence { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string ArchitectureApplicative { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string ArchitectureDonnees { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public string ArchitectureTechnique { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")] 
        public Historique Historique { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public PieceJointe pieceJointe { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public Univers Univers { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public InterfaceUtilisateur InterfaceUtilisateur { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public Contact Contact { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public Fonctionnalite Fonctionnalite { get; set; }

        [Required]
        [BsonElement("valeur")]
        [JsonPropertyName("valeur")]
        public Composant Composant { get; set; }


    }
}
