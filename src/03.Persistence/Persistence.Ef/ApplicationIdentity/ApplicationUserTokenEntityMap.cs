namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserTokenEntityMap : IEntityTypeConfiguration<
        UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");
    }
}