namespace BananaPie.Users.Core.Events;
public class NewUserAddedEvent : BaseDomainEvent
{
    public User User { get; set; }
    public NewUserAddedEvent(User user)
    {
        User = user;
    }
}
