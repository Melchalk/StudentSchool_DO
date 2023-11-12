﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Provider;

#nullable disable

namespace Provider.Migrations
{
    [DbContext(typeof(OfficeDbContext))]
    partial class OfficeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbModels.DbBook", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CityPublishing")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("HallNo")
                        .HasColumnType("int");

                    b.Property<int>("NumberPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("YearPublishing")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("DbModels.DbIssue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("datetime2");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<Guid>("ReaderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReaderId")
                        .IsUnique();

                    b.ToTable("Issues", (string)null);
                });

            modelBuilder.Entity("DbModels.DbIssueBooks", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueBooks", (string)null);
                });

            modelBuilder.Entity("DbModels.DbReader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegistrationAddress")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Readers", (string)null);
                });

            modelBuilder.Entity("DbModels.DbBook", b =>
                {
                    b.HasOne("DbModels.DbIssueBooks", "Issue")
                        .WithMany("Books")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("DbModels.DbIssue", b =>
                {
                    b.HasOne("DbModels.DbReader", "Reader")
                        .WithOne("Issue")
                        .HasForeignKey("DbModels.DbIssue", "ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("DbModels.DbIssueBooks", b =>
                {
                    b.HasOne("DbModels.DbIssue", "Issue")
                        .WithMany("Books")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("DbModels.DbIssue", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DbModels.DbIssueBooks", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DbModels.DbReader", b =>
                {
                    b.Navigation("Issue")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
