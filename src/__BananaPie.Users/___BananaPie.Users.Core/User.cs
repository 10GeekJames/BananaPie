namespace BananaPie.Users.Core;

public class User : BaseEntity<Guid>, IAggregateRoot
{
    public string EmailAddress { get; private set; }
    private List<KnownAlias> _knownAliases = new();
    public IEnumerable<KnownAlias> KnownAliases => _knownAliases.AsReadOnly();
    public DateTime FirstJoinedDate { get; private set; } = DateTime.Now;

    public User(Guid id, string emailAddress)
    {
        if (emailAddress == "")
        {
            throw new Exceptions.NewUserCannotHaveEmptyEmailAddressException();
        }
        Id = id;
        EmailAddress = emailAddress;
    }
    public User(string emailAddress) : this(Guid.Empty, emailAddress)
    {
    }

    public async Task AddKnownAlias(KnownAlias knownAlias)
    {
        await Task.Yield();
        if (_knownAliases.Count(rs => rs.Name == knownAlias.Name) > 0)
        {
            var rs = _knownAliases.FirstOrDefault(rs => rs.Name == knownAlias.Name);
            rs?.IncrementInstanceCounter();
        }
        else
        {
            _knownAliases.Add(knownAlias);
        }
    }
}
