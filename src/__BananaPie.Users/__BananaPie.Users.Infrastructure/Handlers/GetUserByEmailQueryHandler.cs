namespace BananaPie.Users.Infrastructure.Handlers;
public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
{
    private IRepository<User> _repository;
    public GetUserByEmailQueryHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<User> Handle(GetUserByEmailQuery qry, CancellationToken cancellationToken)
    {
        var spec = new UserGetByEmailSpecNoTracking(qry.EmailAddress);
        User result = await _repository.GetBySpecAsync(spec);
        return result;
    }
}
