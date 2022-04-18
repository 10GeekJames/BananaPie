namespace BananaPie.Users.Api.Controllers;

public class UsersController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult> GetUsers()
    {
        var qry = new GetUsersQuery();
        List<BananaPie.Users.Core.User> users = await _mediator.Send(qry);
        return Ok(_mapper.Map<List<UserViewModel>>(users));
    }

    [HttpGet(Name = "GetUsersWithIds")]
    public async Task<ActionResult> GetUsersWithIds()
    {
        var qry = new GetUsersQuery();
        List<BananaPie.Users.Core.User> users = await _mediator.Send(qry);
        return Ok(_mapper.Map<List<UserViewModelWithIds>>(users));
    }
}
