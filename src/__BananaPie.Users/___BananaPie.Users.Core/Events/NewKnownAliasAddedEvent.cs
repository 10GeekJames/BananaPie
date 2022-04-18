namespace BananaPie.Users.Core.Events;
public class NewKnownAliasAddedEvent : BaseDomainEvent
{
    public KnownAlias KnownAlias { get; set; }
    public NewKnownAliasAddedEvent(KnownAlias knownAlias)
    {
        KnownAlias = knownAlias;
    }
}
