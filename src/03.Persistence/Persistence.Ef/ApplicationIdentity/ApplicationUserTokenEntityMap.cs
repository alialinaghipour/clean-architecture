namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserTokenEntityMap : IEntityTypeConfiguration<
        ApplicationUserToken>
{
    public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
    {
        builder.ToTable("ApplicationUserTokens");
    }
}