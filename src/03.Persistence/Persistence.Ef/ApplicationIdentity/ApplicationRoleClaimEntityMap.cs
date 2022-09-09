namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationRoleClaimEntityMap : IEntityTypeConfiguration<
        RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaims");
    }
}