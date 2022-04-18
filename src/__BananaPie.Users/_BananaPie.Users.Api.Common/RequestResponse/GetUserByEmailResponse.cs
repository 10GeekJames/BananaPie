namespace BananaPie.Users.Api.Common.RequestResponse;
public class GetUserByEmailResponse
{
    [Required]
    public UserViewModel User { get; set; }
}
