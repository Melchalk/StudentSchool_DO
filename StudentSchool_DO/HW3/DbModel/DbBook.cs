using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbBook
{
    public const string TableName = "Books";

    public Guid Id { get; set; }
    [StringLength(50)]
    public string Title { get; set; }
    [StringLength(50)]
    public string? Author { get; set; }
    public int NumberPages { get; set; }
    public int YearPublishing { get; set; }
    [StringLength(50)]
    public string? CityPublishing { get; set; }
    public int? HallNo { get; set; }

    public DbIssueBooks? Issue { get; set; }
}

public class DbBookConfiguration : IEntityTypeConfiguration<DbBook>
{
    public void Configure(EntityTypeBuilder<DbBook> builder)
    {
        builder.ToTable(DbBook.TableName);

        builder.HasKey(o => o.Id);
    }
}