namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationRoleEntityMap : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("ApplicationRoles");
    }
}