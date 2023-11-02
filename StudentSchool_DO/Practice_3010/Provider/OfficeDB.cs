using Microsoft.EntityFrameworkCore;
using System;
using DBModels;

namespace Provider;

public class OfficeDB : DbContext
{
    public DbSet<DBUser> Users { get; set; }

    private const string ConnectionString =
      @"Server=mel\sqlexpress;Database=Less;Trusted_Connection=True;Encrypt=False;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DBUser>()
          .HasKey(u => u.id);
    }
}