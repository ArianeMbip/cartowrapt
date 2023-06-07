namespace ApiCartobani.Domain.Univers.DomainEvents;

public sealed class UniversCreated : DomainEvent
{
    public Univers Univers { get; set; } 
}
            