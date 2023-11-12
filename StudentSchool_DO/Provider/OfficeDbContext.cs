﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DbModels;

namespace Provider;

public class OfficeDbContext : DbContext
{
    public DbSet<DbBook> Books { get; set; }
    public DbSet<DbReader> Readers { get; set; }
    public DbSet<DbIssue> Issues { get; set; }
    public DbSet<DbIssueBooks> IssueBooks { get; set; }

    private const string ConnectionString = @"Server=MEL\SQLEXPRESS;Database=Library;Trusted_Connection=True;Encrypt=False;";

    public OfficeDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DbBookConfiguration());
        modelBuilder.ApplyConfiguration(new DbReaderConfiguration());
        modelBuilder.ApplyConfiguration(new DbIssueConfiguration());
        modelBuilder.ApplyConfiguration(new DbIssueBooksConfiguration());
    }
}