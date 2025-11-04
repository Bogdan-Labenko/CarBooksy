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
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}