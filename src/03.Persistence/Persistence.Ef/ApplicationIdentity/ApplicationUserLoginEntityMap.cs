namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserLoginEntityMap : IEntityTypeConfiguration<
        ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder.ToTable("ApplicationUserLogins");
    }
}