namespace BananaPie.Users.Api;
public class Startup
{
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
        Configuration = config;
        _env = env;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        string connectionString =
            Configuration.GetConnectionString("SqliteConnection"); //Configuration.GetConnectionString("DefaultConnection");

        services.AddAutoMapper(typeof(BananaPie.Users.Api.Common.Class1).GetTypeInfo().Assembly);

        services.AddSingleton<SeedBananaPieUsersData>();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration, "Serilog")
            
        ;
 
        /* services.AddLogging(loggingBuilder =>
      	    loggingBuilder.AddSerilog(dispose: true));
 */
        services.AddSerilogServices(logger);
        //services.AddSingleton<Serilog.ILogger>(s => logger.CreateLogger());
        
        //var provider = services.BuildServiceProvider();

        services.AddDbContext(connectionString);

        services
            .AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;
            });
        services.AddRazorPages();
        services
            .AddCors(opt =>
            {
                opt
                    .AddDefaultPolicy(builder =>
                    {
                        builder
                            .WithOrigins(
                                "http://localhost:5004",
                                "https://localhost:5005",
                                "http://localhost:5014",
                                "https://localhost:5015",
                                "http://localhost:5021",
                                "https://localhost:5021"
                            )
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        services
            .AddSwaggerGen(c =>
            {
                c
                    .SwaggerDoc("v1",
                    new OpenApiInfo { Title = "My API", Version = "v1" });
                c.EnableAnnotations();
            });

        // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
        services
            .Configure<ServiceConfig>(config =>
            {
                config.Services = new List<ServiceDescriptor>(services);

                // optional - default path to view services is /listallservices - recommended to choose your own path
                config.Path = "/listservices";
            });

        services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

        services
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer",
            options =>
            {
                options.Authority = "https://BananaPie.com:5003";
                /* options.Authority = "https://localhost:5003"; */

                options.Audience = "BananaPie-api";
                // options.MetadataAddress = (authorityEnvVar != null ? authorityEnvVar : "http://localhost:5002") + "/.well-known/openid-configuration";
            });

        services
            .AddAuthorization(options =>
            {
                options
                    .AddPolicy("delete-access",
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy
                            .RequireClaim("scope",
                            "weather.delete",
                            "individual");
                    });

                options
                    .AddPolicy("write-access",
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy
                            .RequireClaim("scope",
                            "weather.write",
                            "weather.delete",
                            "individual");
                    });

                options
                    .AddPolicy("read-access",
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy
                            .RequireClaim("scope",
                            "weather.read",
                            "weather.write",
                            "weather.delete",
                            "individual");
                    });
            });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new DefaultCoreModule());
        builder.RegisterModule(new BananaPieUsersCoreModule());
        builder.RegisterModule(new BananaPieUsersInfrastructureModule(isDevelopment: true));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.EnvironmentName == "Development")
        {
            app.UseDeveloperExceptionPage();
            app.UseShowAllServicesMiddleware();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseRouting();

        //app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseCors();
        app.UseAuthentication();

        app.UseAuthorization();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
        app
            .UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

        app
            .UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        Log.Logger.Warning("bad things happen");
    }

   
}
