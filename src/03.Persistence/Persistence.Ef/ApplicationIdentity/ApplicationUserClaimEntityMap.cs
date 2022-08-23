namespace Persistence.Ef.ApplicationIdentity;

internal class
    ApplicationUserClaimEntityMap : IEntityTypeConfiguration<
        ApplicationUserClaim>
{
    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder.ToTable("ApplicationUserClaims");
    }
}