namespace ApiCartobani.Domain.ValeurAttributs.Dtos;

public sealed class ValeurAttributDto 
{
        public Guid Id { get; set; }
        public string Valeur { get; set; }
        public Guid Attribut { get; set; }
        public Guid Environnement { get; set; }
}
