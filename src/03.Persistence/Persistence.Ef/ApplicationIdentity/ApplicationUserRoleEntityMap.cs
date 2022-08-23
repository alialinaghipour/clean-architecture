namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserRoleEntityMap : IEntityTypeConfiguration<
        ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable("ApplicationUserRoles");
    }
}