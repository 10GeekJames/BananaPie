using System.Globalization;
using System.Data.Common;
namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUserByIdRequest
{
    public const string Route = "/User/GetById{WithIds}?Id={guid:id}";

    [Required]
    public Guid Id { get; set; }

    public GetUserByIdRequest() { }
    public GetUserByIdRequest(Guid id)
    {
        Id = id;
    }

    public static string BuildRoute(Guid id)
    {
        return Route
            .Replace("{guid:id}", id.ToString())
            .Replace("{WithIds}", "")
        ;
    }
     public static string BuildRouteWithIds(Guid id)
    {
        return Route
            .Replace("{guid:id}", id.ToString())
            .Replace("{WithIds}", "WithIds")
        ;
    }
}
