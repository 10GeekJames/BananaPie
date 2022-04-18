public static class SerilogServices
{
    public static IServiceCollection AddSerilogServices(
           this IServiceCollection services,
           LoggerConfiguration configuration)
    {
        Log.Logger = configuration.CreateLogger();
        AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
        return services.AddSingleton(Log.Logger);
    }
}