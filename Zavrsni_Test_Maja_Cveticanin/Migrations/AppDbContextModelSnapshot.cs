// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zavrsni_Test_Maja_Cveticanin.Models.Context;

#nullable disable

namespace Zavrsni_Test_Maja_Cveticanin.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Zavrsni_Test_Maja_Cveticanin.Models.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Zavrsni_Test_Maja_Cveticanin.Models.Stan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrojKvadrata")
                        .HasColumnType("int");

                    b.Property<string>("BrojStana")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("CenaStana")
                        .HasColumnType("float");

                    b.Property<string>("TipStana")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ZgradaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZgradaId");

                    b.ToTable("Stanovi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrojKvadrata = 23,
                            BrojStana = "001",
                            CenaStana = 105000.0,
                            TipStana = "Garsonjera",
                            ZgradaId = 1
                        },
                        new
                        {
                            Id = 2,
                            BrojKvadrata = 43,
                            BrojStana = "021",
                            CenaStana = 42000.0,
                            TipStana = "Dvosoban",
                            ZgradaId = 2
                        },
                        new
                        {
                            Id = 3,
                            BrojKvadrata = 51,
                            BrojStana = "501",
                            CenaStana = 47000.0,
                            TipStana = "Dvosoban",
                            ZgradaId = 2
                        },
                        new
                        {
                            Id = 4,
                            BrojKvadrata = 75,
                            BrojStana = "610",
                            CenaStana = 180000.0,
                            TipStana = "Dvosoban",
                            ZgradaId = 3
                        },
                        new
                        {
                            Id = 5,
                            BrojKvadrata = 114,
                            BrojStana = "610",
                            CenaStana = 170000.0,
                            TipStana = "Trosoban",
                            ZgradaId = 1
                        });
                });

            modelBuilder.Entity("Zavrsni_Test_Maja_Cveticanin.Models.Zgrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("GodinaIzgradnje")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Zgrade");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adresa = "Ulica Koste Racina 4",
                            GodinaIzgradnje = 0
                        },
                        new
                        {
                            Id = 2,
                            Adresa = "Ulica Marka Miljanova 14",
                            GodinaIzgradnje = 0
                        },
                        new
                        {
                            Id = 3,
                            Adresa = "Bulevar Cara Lazara 113",
                            GodinaIzgradnje = 0
                        },
                        new
                        {
                            Id = 4,
                            Adresa = "",
                            GodinaIzgradnje = 0
                        });
                });

            modelBuilder.Entity("Zavrsni_Test_Maja_Cveticanin.Models.Stan", b =>
                {
                    b.HasOne("Zavrsni_Test_Maja_Cveticanin.Models.Zgrada", "Zgrada")
                        .WithMany()
                        .HasForeignKey("ZgradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zgrada");
                });
#pragma warning restore 612, 618
        }
    }
}
