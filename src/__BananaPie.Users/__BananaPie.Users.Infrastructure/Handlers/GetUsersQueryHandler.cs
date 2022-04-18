namespace BananaPie.Users.Infrastructure.Handlers;
public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    private IRepository<User> _repository;
    public GetUsersQueryHandler(IRepository<User> repository)
    {
        _repository = repository;
    }
    public async Task<List<User>> Handle(GetUsersQuery qry, CancellationToken cancellationToken)
    {
        var spec = new GetAllUsersSpecNoTracking();
        return await _repository.ListAsync(spec);
    }
}