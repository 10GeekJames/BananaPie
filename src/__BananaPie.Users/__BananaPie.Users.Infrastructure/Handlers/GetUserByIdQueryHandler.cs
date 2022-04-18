namespace BananaPie.Users.Infrastructure.Handlers;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private IRepository<User> _repository;
    public GetUserByIdQueryHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<User> Handle(GetUserByIdQuery qry, CancellationToken cancellationToken)
    {
        var spec = new UserGetByIdSpecNoTracking(qry.Id);
        User result = await _repository.GetBySpecAsync(spec);
        return result;
    }
}
