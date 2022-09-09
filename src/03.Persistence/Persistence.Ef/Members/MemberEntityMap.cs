using Domain.Members;

namespace Persistence.Ef.Members;

public class MemberEntityMap : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> entity)
    {
        entity
            .ToTable("Members");

        entity
            .HasKey(_ => _.Id);

        entity
            .Property(_ => _.Id)
            .ValueGeneratedNever()
            .HasMaxLength(450);

        entity
            .Property(_ => _.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        
        entity
            .Property(_ => _.LastName)
            .IsRequired()
            .HasMaxLength(50);
        
        entity
            .Property(_ => _.Email)
            .IsRequired()
            .HasMaxLength(250);
    }
}