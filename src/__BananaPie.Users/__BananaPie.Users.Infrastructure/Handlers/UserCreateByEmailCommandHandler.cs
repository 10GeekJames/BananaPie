namespace BananaPie.Users.Infrastructure.Handlers; 
public class UserCreateByEmailCommandHandler : IRequestHandler<UserCreateByEmailCommand, User>
{
    private IRepository<User> _repository;
    private ILogger _logger;

    public UserCreateByEmailCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<User> Handle(UserCreateByEmailCommand cmd, CancellationToken cancellationToken)
    {
        var user = new User(cmd.EmailAddress);
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
        return user;
    }
}
