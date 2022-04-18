namespace BananaPie.Users.Core.Tests;

public class BananaPieCoreUsersUnitTests
{
    private string email1ForTesting = "bob@bob.com";
    
    [Fact]
    public void ConstructorTest()
    {
        var bob = new User(email1ForTesting);
        Assert.Matches(email1ForTesting, bob.EmailAddress);
    }

    [Fact]
    public void InvalidEmailAddressConstructorTest()
    {
        Assert.Throws<NewUserCannotHaveEmptyEmailAddressException>(() => {
            var bob = new User("");
        });               
    }
}