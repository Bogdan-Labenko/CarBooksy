using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBooksy.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .ValueGeneratedNever();
        builder.Property(u => u.Name)
            .HasMaxLength(UserConstraints.NameMaxLength)
            .IsRequired();
        builder.Property(u => u.LastName)
            .HasMaxLength(UserConstraints.LastNameMaxLength)
            .IsRequired();
        
        builder.OwnsOne(u => u.ContactInfo, ci =>
        {
            ci.Property(c => c.Email)
                .HasMaxLength(ContactInfoConstraints.EmailMaxLength)
                .IsRequired();

            ci.Property(c => c.Phone)
                .HasMaxLength(ContactInfoConstraints.PhoneNumberMaxLength)
                .IsRequired();

            ci.Property(c => c.Fax)
                .HasMaxLength(ContactInfoConstraints.FaxMaxLength)
                .IsRequired(false);

            ci.HasIndex(c => c.Email).IsUnique();
            ci.HasIndex(c => c.Phone).IsUnique();
        });

        builder.Property(u => u.CompanyId)
            .IsRequired(false);
        
        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(u => u.Birthday)
            .IsRequired();
        
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Users_Birthday_NotFuture",
                "\"Birthday\" <= CURRENT_DATE");
            t.HasCheckConstraint("CK_Users_Birthday_MinYear",
                "\"Birthday\" >= DATE '1900-01-01'");
        });
    }
}