namespace BananaPie.Users.Api.Tests;
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<BananaPie.Users.Api.Startup>
{
    /// <summary>
    /// Overriding CreateHost to avoid creating a separate ServiceProvider per this thread:
    /// https://github.com/dotnet-architecture/eShopOnWeb/issues/465
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = builder.Build();

        // Get service provider.
        var serviceProvider = host.Services;

        // Create a scope to obtain a reference to the database
        // context (AppDbContext).
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AppDbContext>();
            
            // Ensure the database is created.
            db.Database.EnsureCreated();

            var seedBananaPieUsersData = scopedServices.GetRequiredService<SeedBananaPieUsersData>();
            seedBananaPieUsersData.PopulateTestData(db);            
        }

        host.Start();
        return host;
    }

    protected override IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHost((builder) =>
        {
            builder.UseStartup<Startup>();
        });
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureServices(services =>
            {
                    // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<AppDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var logger = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(ILogger));

                if (logger != null)
                {
                    services.Remove(logger);
                }
                services.AddScoped<ILogger>((m) => new Mock<ILogger>().Object);
                
                // This should be set for each individual test run
                string inMemoryCollectionName = Guid.NewGuid().ToString();

                    // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase(inMemoryCollectionName);
                });
                
                services.AddScoped<IMediator, NoOpMediator>();

                services.AddControllers().AddApplicationPart(typeof(Startup).Assembly);
            });
    }
}