namespace BananaPie.Users.Api.Tests.ApiEndpoints;
[Collection("Sequential")]
public class GetUserById : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public GetUserById(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }


    [Fact]
    public async Task ReturnsSeedBananaPieUserGivenGuid()
    {
        var id = SeedBananaPieUsersData.User1Id;

        var result = await _client.GetAndDeserialize<UserViewModelWithIds>("http://localhost:5004" + GetUserByIdRequest.BuildRouteWithIds(id));

        Assert.Equal(SeedBananaPieUsersData.User1Id, result?.Id);
    }

    [Fact]
    public async Task ReturnsNotFoundGivenBadGuid()
    {
        var id = new Guid("11111111111111111111111111111111");

        string route = "http://localhost:5004" + GetUserByIdRequest.BuildRoute(id);

        var bob = await _client.GetAndEnsureNotFound(route);
    }
}
