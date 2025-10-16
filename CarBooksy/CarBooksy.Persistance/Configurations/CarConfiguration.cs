using CarBooksy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBooksy.Persistance.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(c => c.Make)
            .IsRequired();
        builder.Property(c => c.Model)
            .IsRequired();
        builder.Property(c => c.ProductionYear)
            .IsRequired();
        builder.Property(c => c.PlateNumber)
            .IsRequired();
        builder.Property(c => c.VinCode)
            .IsRequired();
        builder.Property(c => c.Status)
            .IsRequired();
        builder.Property(c => c.BodyType)
            .IsRequired();
    }
}