namespace Persistence.Ef.ApplicationIdentity;

public class
    ApplicationRoleEntityMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
    }
}