using CarBooksy.Domain.Entities;
using CarBooksy.Shared.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBooksy.Persistance.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(c => c.Make)
            .HasMaxLength(CarConstraints.MakeMaxLength)
            .IsRequired();
        builder.Property(c => c.Model)
            .HasMaxLength(CarConstraints.ModelMaxLength)
            .IsRequired();
        builder.Property(c => c.ProductionYear)
            .IsRequired();
        builder.Property(c => c.PlateNumber)
            .HasMaxLength(CarConstraints.PlateNumberMaxLength)
            .IsRequired();
        builder.Property(c => c.VinCode)
            .HasMaxLength(CarConstraints.VinCodeLength)
            .HasConversion(v => v.ToUpperInvariant(),
                v => v)
            .IsRequired();
        builder.Property(c => c.Status)
            .IsRequired();
        builder.Property(c => c.BodyType)
            .IsRequired();

        builder.Property(c => c.CompanyId)
            .IsRequired(false);
        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasIndex(c => c.PlateNumber);
        
        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Cars_VinCode_Length", 
                "CHAR_LENGTH(TRIM(BOTH FROM \"VinCode\")) = " + CarConstraints.VinCodeLength);

            t.HasCheckConstraint("CK_Cars_VinCode_Upper", 
                "\"VinCode\" = UPPER(\"VinCode\")");
            
            t.HasCheckConstraint("CK_Cars_ProductionYear_Range", "\"ProductionYear\" BETWEEN 1900 AND EXTRACT(YEAR FROM CURRENT_DATE)");
        });
    }
}