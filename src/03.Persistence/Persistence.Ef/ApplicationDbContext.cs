namespace Persistence.Ef;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser
    , ApplicationRole
    , string
    , ApplicationUserClaim
    , ApplicationUserRole
    , ApplicationUserLogin
    , ApplicationRoleClaim
    , ApplicationUserToken>
{
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