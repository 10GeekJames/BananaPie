namespace BananaPie.Users.Api.Common.ViewModels;
public class UserViewModel
{
    public string EmailAddress { get; set; } = "";
    public List<KnownAliasViewModel> KnownAliases { get; set; } = new();

    public DateTime FirstJoinedDate { get; set; }
}
