using System.Linq.Expressions;
using CarBooksy.Domain.Common;
using CarBooksy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CarBooksy.Persistance;

public class ApplicationDbContext(IConfiguration config) : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(new NpgsqlConnection(config["Database:ConnectionString"]));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Applying entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        //IsDeleted query filter
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                // Creating expression e => !e.IsDeleted
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var filter = Expression.Lambda(
                    Expression.Equal(property, Expression.Constant(false)),
                    parameter
                );

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        ApplyAuditInfo();
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void ApplyAuditInfo()
    {
        var entries = ChangeTracker.Entries<IAuditEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.CreatedBy = Guid.Empty; // TODO: change to current user
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;
                entry.Entity.ModifiedBy = Guid.Empty; // TODO: change to current user
            }
        }
    }
}