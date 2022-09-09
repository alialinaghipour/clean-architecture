namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationUserRoleEntityMap : IEntityTypeConfiguration<
        UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");
    }
}