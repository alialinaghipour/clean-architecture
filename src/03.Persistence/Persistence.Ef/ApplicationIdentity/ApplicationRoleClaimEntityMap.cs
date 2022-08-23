namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationRoleClaimEntityMap : IEntityTypeConfiguration<
        ApplicationRoleClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        builder.ToTable("ApplicationRoleClaims");
    }
}