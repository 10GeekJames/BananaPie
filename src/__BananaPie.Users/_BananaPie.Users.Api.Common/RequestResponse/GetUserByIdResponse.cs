namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUserByIdResponse
{
    [Required]
    public UserViewModel User { get; set; }
}
