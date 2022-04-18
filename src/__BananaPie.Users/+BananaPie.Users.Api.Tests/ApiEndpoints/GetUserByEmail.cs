using System.Runtime.CompilerServices;
namespace BananaPie.Users.Api.Tests.ApiEndpoints;
[Collection("Sequential")]
public class GetUserByEmail : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public GetUserByEmail(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnsSeedBananaPieUserGivenEmailAddress()
    {
        var email = SeedBananaPieUsersData.User1Email;
        
        var result = await _client.GetAndDeserialize<UserViewModelWithIds>("http://localhost:5004" + GetUserByEmailRequest.BuildRouteWithIds(email));

        Assert.Equal(email, result?.EmailAddress);        
    }    
}
