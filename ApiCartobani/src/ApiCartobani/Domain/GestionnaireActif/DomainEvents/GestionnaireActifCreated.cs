namespace ApiCartobani.Domain.GestionnaireActif.DomainEvents;

public sealed class GestionnaireActifCreated : DomainEvent
{
    public GestionnaireActif GestionnaireActif { get; set; } 
}
            