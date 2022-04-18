namespace BananaPie.Users.Api.Common.Automaps; 
public class KnownAliasToVM : Profile
{
    public override string ProfileName
    {
        get { return "KnownAliasToVM"; }
    }
    public KnownAliasToVM()
    {
        CreateMap<KnownAlias, KnownAliasViewModel>().ReverseMap();
    }
}
