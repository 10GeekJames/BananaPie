namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUserByEmailRequest
{
    public const string Route = "/User/GetByEmail{WithIds}?EmailAddress={string:emailAddress}";

    [Required]
    public string EmailAddress { get; set; }

    public GetUserByEmailRequest(){}
    public GetUserByEmailRequest(string emailAddress){
        EmailAddress = emailAddress;
    }

    public static string BuildRoute(string emailAddress)
    {
        return Route
            .Replace(@"{string:emailAddress}", emailAddress)
            .Replace("{WithIds}", "");
    }
    public static string BuildRouteWithIds(string emailAddress)
    {
        return Route
            .Replace(@"{string:emailAddress}", emailAddress)
            .Replace("{WithIds}", "WithIds");;
    }
}
