namespace BananaPie.Users.Infrastructure.Data;
public class AppDbContext : DbContext
{
    private readonly IMediator _mediator;
    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }
    public DbSet<User> Users { get; set; }
    public DbSet<KnownAlias> KnownAliases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries().Where(E => E.State == EntityState.Added || E.State == EntityState.Modified).ToList();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.GetType().GetProperty("CreatedOn") != null)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("UpdatedOn").CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedOn").CurrentValue = DateTime.Now;
                    entityEntry.Property("UpdatedOn").CurrentValue = DateTime.Now;
                }
            }
        }

        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity<System.Guid>>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
