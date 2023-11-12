using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;

namespace DbModels;

public class DbIssueBooks
{
    public const string TableName = "IssueBooks";

    public Guid IssueId { get; set; }
    public Guid BookId { get; set; }

    public IList<DbBook> Books { get; set; } = new List<DbBook>();
    public DbIssue Issue { get; set; }
}

public class DbIssueBooksConfiguration : IEntityTypeConfiguration<DbIssueBooks>
{
    public void Configure(EntityTypeBuilder<DbIssueBooks> builder)
    {
        builder.ToTable(DbIssueBooks.TableName);

        builder.HasKey(u => u.IssueId);
        builder.HasKey(u => u.BookId);

        builder
          .HasMany(o => o.Books)
          .WithOne(u => u.Issue)
          .HasForeignKey(u => u.Id)
          .HasPrincipalKey(t => t.BookId);
    }
}