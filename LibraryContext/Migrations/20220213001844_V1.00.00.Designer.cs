﻿// <auto-generated />
using LibraryContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryContext.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20220213001844_V1.00.00")]
    partial class V10000
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LibraryModels.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A. Portugal"
                        },
                        new
                        {
                            Id = 2,
                            Description = "B. Espanha"
                        },
                        new
                        {
                            Id = 3,
                            Description = "C. Argentina"
                        },
                        new
                        {
                            Id = 4,
                            Description = "D. Malta"
                        },
                        new
                        {
                            Id = 5,
                            Description = "A. Gato"
                        },
                        new
                        {
                            Id = 6,
                            Description = "B. Coelho"
                        },
                        new
                        {
                            Id = 7,
                            Description = "C. Papagaio"
                        },
                        new
                        {
                            Id = 8,
                            Description = "D. Coentros"
                        });
                });

            modelBuilder.Entity("LibraryModels.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerId = 2,
                            Description = "Qual destes está mais próximo de França?"
                        },
                        new
                        {
                            Id = 2,
                            AnswerId = 8,
                            Description = "Qual destes fala?"
                        });
                });

            modelBuilder.Entity("LibraryModels.Question", b =>
                {
                    b.HasOne("LibraryModels.Answer", "Answer")
                        .WithMany("Questions")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("LibraryModels.Answer", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
