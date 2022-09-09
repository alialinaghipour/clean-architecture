namespace Persistence.Ef.ApplicationIdentity;

public class ApplicationUserEntityMap
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");
        
        builder
            .HasKey(_ => _.Id);
        
        builder
            .Property(_ => _.Id)
            .ValueGeneratedNever()
            .HasMaxLength(450);

        builder
            .Property(_ => _.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(_ => _.NormalizedUserName)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(_ => _.PhoneNumber)
            .IsRequired(false);
    }
}