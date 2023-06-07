namespace ApiCartobani.Domain.Univers.DomainEvents;

public sealed class UniversUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            