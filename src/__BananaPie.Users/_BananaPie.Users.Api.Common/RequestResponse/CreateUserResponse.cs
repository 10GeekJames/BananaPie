namespace BananaPie.Users.Api.Common.RequestResponse;
public class CreateUserResponse
{
    [Required]
    public UserViewModel User { get; set; }
}
