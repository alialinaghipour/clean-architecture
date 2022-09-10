namespace Persistence.Ef;

public class ApplicationDbContext : IdentityDbContext<User
    , Role
    , string
    , UserClaim
    , UserRole
    , UserLogin
    , RoleClaim
    , UserToken>
{
    public ApplicationDbContext(string dbConnectionStrings)
        : this(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(dbConnectionStrings).Options)
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}