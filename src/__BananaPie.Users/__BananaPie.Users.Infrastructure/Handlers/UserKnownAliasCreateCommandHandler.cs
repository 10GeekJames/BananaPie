namespace BananaPie.Users.Infrastructure.Handlers;
public class UserKnownAliasCreateCommandHandler : IRequestHandler<UserKnownAliasCreateCommand, KnownAlias>
{
    private IRepository<User> _repository;
    public UserKnownAliasCreateCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<KnownAlias> Handle(UserKnownAliasCreateCommand cmd, CancellationToken cancellationToken)
    {
        var spec = new UserGetByEmailSpecNoTracking(cmd.EmailAddress);
        User result = await _repository.GetBySpecAsync(spec);
        var knownAlias = new KnownAlias(cmd.UserAlias);
        await result.AddKnownAlias(knownAlias);
        await _repository.SaveChangesAsync();
        return knownAlias;
    }
}
