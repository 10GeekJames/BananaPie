namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUsersRequest
{
    public const string Route = "/Users/GetUsers";
    public GetUsersRequest() { }
    public static string BuildRoute()
    {
        return Route;
    }
}
