﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DbModels;

public class DbReader
{
    public const string TableName = "Readers";

    public Guid Id { get; set; }
    [StringLength(50)]
    public string Fullname {  get; set; }
    [StringLength(50)]
    public string Telephone {  get; set; }
    [StringLength(50)]
    public string? RegistrationAddress { get; set; }
    public int? Age { get; set; }

    public DbIssue Issue { get; set; }
}

public class DbReaderConfiguration : IEntityTypeConfiguration<DbReader>
{
    public void Configure(EntityTypeBuilder<DbReader> builder)
    {
        builder.ToTable(DbReader.TableName);

        builder.HasKey(o => o.Id);
    }
}