namespace BananaPie.Users.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<Serilog.ILogger>();                
            try
            {
                var context = services.GetRequiredService<AppDbContext>();                
                var seedBananaPieUsersData = services.GetRequiredService<SeedBananaPieUsersData>();

                //                    context.Database.Migrate();
                context.Database.EnsureCreated();
                seedBananaPieUsersData.Initialize(services);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddSerilog();
                        // logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure
                });
            });
}
