namespace Persistence.Ef.ApplicationIdentity;

internal class
    ApplicationUserClaimEntityMap : IEntityTypeConfiguration<
        UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");
    }
}