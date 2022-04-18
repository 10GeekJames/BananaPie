namespace BananaPie.Users.Api.Common.RequestResponse;
public class CreateUserRequest
{
    public const string Route = "/User/Create";

    [Required]
    public string Name { get; set; }

    public CreateUserRequest(){}
    public static string BuildRoute() {
        return Route;
    }
}
