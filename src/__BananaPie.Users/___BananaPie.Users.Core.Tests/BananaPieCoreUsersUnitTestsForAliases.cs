namespace BananaPie.Users.Core.Tests;

public class BananaPieCoreUsersUnitTestsForAliases
{
    private string email1ForTesting = "bob@bob.com";
    private string alias1 = "larry the laughter";
    private string alias2 = "johnny the joystick";
    private string alias3 = "franky the gamer";

    [Fact]
    public async Task AddingAliasTest1()
    {
        var User1 = new User(email1ForTesting);
        Assert.Equal(0, User1.KnownAliases.Count());
        await User1.AddKnownAlias(new KnownAlias(alias1));
        await User1.AddKnownAlias(new KnownAlias(alias2));
        await User1.AddKnownAlias(new KnownAlias(alias3));
        Assert.Equal(3, User1.KnownAliases.Count());
    }   
   
}