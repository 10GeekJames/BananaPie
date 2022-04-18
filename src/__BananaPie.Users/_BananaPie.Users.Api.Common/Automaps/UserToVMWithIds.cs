namespace BananaPie.Users.Api.Common.Automaps;
public class UserToVMWithIds : Profile
{
    public override string ProfileName
    {
        get { return "UserToVMWithIds"; }
    }
    public UserToVMWithIds()
    {
        CreateMap<User, UserViewModelWithIds>().ReverseMap();
    }
}
