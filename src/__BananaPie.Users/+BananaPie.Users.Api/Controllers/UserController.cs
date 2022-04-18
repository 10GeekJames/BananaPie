namespace BananaPie.Users.Api.Controllers;
public class UserController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly Serilog.ILogger _logger;

    public UserController(IMediator mediator, IMapper mapper, Serilog.ILogger logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult> GetByEmail([FromQuery] GetUserByEmailQuery qry)
    {
        //var qry = new GetUserByEmailQuery(request.EmailAddress);
        var user = await _mediator.Send(qry);
        if (user == null)
        {
            _logger.Warning($"{qry.EmailAddress} does not result in any data");
            return NotFound();
        }
        return Ok(_mapper.Map<UserViewModel>(user));
    }

    [HttpGet]
    public async Task<ActionResult> GetById([FromQuery] GetUserByIdQuery qry)
    {
        var user = await _mediator.Send(qry);
        if (user == null)
        {
            _logger.Warning($"{qry.Id} does not result in any data");
            return NotFound();
        }
        return Ok(_mapper.Map<UserViewModel>(user));
    }


    [HttpGet]
    public async Task<ActionResult> GetByEmailWithIds([FromQuery] GetUserByEmailQuery qry)
    {
        //var qry = new GetUserByEmailQuery(request.EmailAddress);
        var user = await _mediator.Send(qry);
        if (user == null)
        {
            _logger.Warning($"{qry.EmailAddress} does not result in any data");
        }
        return Ok(_mapper.Map<UserViewModelWithIds>(user));
    }

    [HttpGet]
    public async Task<ActionResult> GetByIdWithIds([FromQuery] GetUserByIdQuery qry)
    {
        BananaPie.Users.Core.User user = await _mediator.Send(qry);
        if (user == null)
        {
            _logger.Warning($"{qry.Id} does not result in any data");
        }
        return Ok(_mapper.Map<UserViewModelWithIds>(user));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromQuery] UserCreateByEmailCommand cmd)
    {
        //var qry = new UserCreateByEmailCommand(userName);
        BananaPie.Users.Core.User user = await _mediator.Send(cmd);
        if (user == null)
        {
            _logger.Warning($"{cmd.EmailAddress} did not create any data");
        }
        return Ok(_mapper.Map<UserViewModel>(user));
    }
}
