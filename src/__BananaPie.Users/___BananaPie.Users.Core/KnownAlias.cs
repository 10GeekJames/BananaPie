namespace BananaPie.Users.Core;

public class KnownAlias : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public DateTime FirstSeen { get; private set; } = DateTime.Now;
    public int InstanceUsageCount { get; private set; } = 1;

    public KnownAlias(string name)
    {
        if(name == "") {
            throw new KnownAliasCannotBeEmptyException();
        }        
        Name = name;
    }
    public async Task IncrementInstanceCounter() {
        await Task.Yield();
        InstanceUsageCount++;
    }
}
