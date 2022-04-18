namespace BananaPie.Users.Api.Tests.ApiEndpoints;
[Collection("Sequential")]
public class UsersList : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public UsersList(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

}
