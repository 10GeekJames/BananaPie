namespace BananaPie.Users.Api.Common.ViewModels;

public class KnownAliasViewModel
{
    public string Name { get; set; } = "";
    public DateTime FirstSeen { get; set; } = DateTime.Now;
    public int InstanceUsageCount { get; set; } = 1;
}
