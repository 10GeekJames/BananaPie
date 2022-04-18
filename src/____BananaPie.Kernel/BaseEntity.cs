namespace BananaPie.Kernel;
public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }

    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}
