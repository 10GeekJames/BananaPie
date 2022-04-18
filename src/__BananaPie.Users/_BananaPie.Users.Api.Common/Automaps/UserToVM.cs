namespace BananaPie.Users.Api.Common.Automaps;
public class UserToVM : Profile
{
    public override string ProfileName
    {
        get { return "UserToVM"; }
    }
    public UserToVM()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
    }
}
