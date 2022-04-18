namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUsersResponse
{
    [Required]
    public IEnumerable<UserViewModel> User { get; set; }
}
