using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBooksy.Persistance.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(c => c.Id)
            .ValueGeneratedNever();
        builder.Property(c => c.Name)
            .HasMaxLength(CompanyConstraints.NameMaxLength)
            .IsRequired();
        builder.Property(c => c.NIP)
            .IsRequired();

        builder.OwnsOne(c => c.ContactInfo, ci =>
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
        });

        builder.OwnsOne(c => c.Address, a =>
        {
            a.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(AddressConstraints.CountryMaxLength);

            a.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(AddressConstraints.CityMaxLength);

            a.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(AddressConstraints.StreetMaxLength);

            a.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(AddressConstraints.ZipCodeMaxLength);
        });
        
        builder.HasIndex(c => c.NIP)
            .IsUnique();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Companies_NIP_Length",
                "CHAR_LENGTH(TRIM(BOTH FROM \"NIP\")) =  " + CompanyConstraints.NipLength);
        });
    }
}