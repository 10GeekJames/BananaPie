namespace BananaPie.Kernel;
public abstract class BaseEntityTracked<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
}
