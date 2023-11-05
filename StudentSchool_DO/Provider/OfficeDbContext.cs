using Microsoft.EntityFrameworkCore;
using DbModels;
namespace Provider;

public class OfficeDbContext : DbContext
{
    public DbSet<DbBook> Books { get; set; }

    private const string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbBook>()
          .HasKey(u => u.Id);
    }
}