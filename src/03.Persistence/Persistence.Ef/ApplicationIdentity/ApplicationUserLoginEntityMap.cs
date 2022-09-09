namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserLoginEntityMap : IEntityTypeConfiguration<
        UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("UserLogins");
    }
}