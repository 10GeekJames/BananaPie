namespace BananaPie.Users.Api.Tests.ApiEndpoints;
[Collection("Sequential")]
public class HealthCheck : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public HealthCheck(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task HealthCheckPasses()
    {
        var result = await _client.GetStringAsync("http://localhost:5004" + "/HealthCheck/Get");

        Assert.NotEqual("", result);
    }
}
