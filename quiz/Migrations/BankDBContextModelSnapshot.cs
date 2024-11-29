﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quiz.reposetories;

#nullable disable

namespace quiz.Migrations
{
    [DbContext(typeof(BankDBContext))]
    partial class BankDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("quiz.Entities.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nchar(16)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("tries")
                        .HasColumnType("int");

                    b.HasKey("CardNumber");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("quiz.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nchar(16)");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nchar(16)");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isSuccessful")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("quiz.Entities.Transaction", b =>
                {
                    b.HasOne("quiz.Entities.Card", "DCard")
                        .WithMany("RecievedTransactions")
                        .HasForeignKey("DestinationCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("quiz.Entities.Card", "Card")
                        .WithMany("SentTransactions")
                        .HasForeignKey("SourceCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("DCard");
                });

            modelBuilder.Entity("quiz.Entities.Card", b =>
                {
                    b.Navigation("RecievedTransactions");

                    b.Navigation("SentTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
