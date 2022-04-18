namespace BananaPie.Users.Api;
public class SeedBananaPieUsersData
{
    private IMediator _mediator;
    private DbContextOptions<AppDbContext> _dbContext;
    public SeedBananaPieUsersData(DbContextOptions<AppDbContext> dbContext, IMediator mediator)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }
    public void Initialize(IServiceProvider serviceProvider)
    {
        using (
            var dbContext = new AppDbContext(_dbContext, _mediator)
        )
        {
            PopulateTestData(dbContext);
        }
    }

    public static Guid User1Id = new Guid("aaa22aaaaaaaaaaaaaaaa7f91b373b32");
    public static Guid User2Id = new Guid("bbb22aaaaaaaaaaaaaaaa7f91b373b32");
    public static string User1Email = "bob@bob.com";
    public static string User2Email = "frank@bob.com";
    public static string User2Alias1 = "gammerx";
    public static string User2Alias2 = "xMetax";

    public void PopulateTestData(AppDbContext dbContext)
    {
        var checkForData = dbContext.Users.FirstOrDefault(rs => rs.Id == User1Id);
        if (checkForData == null)
        {
            var user1 = new User(User1Id, User1Email);
            dbContext.Users.Add(user1);

            var user2 = new User(User2Id, User2Email);

            user2.AddKnownAlias(new KnownAlias(User2Alias1));
            user2.AddKnownAlias(new KnownAlias(User2Alias2));

            dbContext.Users.Add(user2);

            dbContext.SaveChanges();
        }
    }
}
