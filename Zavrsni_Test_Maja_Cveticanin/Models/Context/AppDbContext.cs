using Microsoft.EntityFrameworkCore;
using Zavrsni_Test_Maja_Cveticanin.Models.Models;

namespace Zavrsni_Test_Maja_Cveticanin.Models.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Stan> Stanovi { get; set; }
        public DbSet<Zgrada> Zgrade { get; set; }
        public DbSet<ApplicationUser> User { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zgrada>().HasData(
               new Zgrada() { Id = 1, Adresa = "Ulica Koste Racina 4"},
               new Zgrada() { Id = 2, Adresa = "Ulica Marka Miljanova 14" },
               new Zgrada() { Id = 3, Adresa = "Bulevar Cara Lazara 113" },               new Zgrada() { Id = 4, Adresa = "" }

           );

            modelBuilder.Entity<Stan>().HasData(
              new Stan() { Id = 1,BrojStana = "001", TipStana = "Garsonjera", BrojKvadrata = 23, CenaStana = 105000, ZgradaId = 1 },
              new Stan() { Id = 2, BrojStana = "021", TipStana = "Dvosoban", BrojKvadrata = 43, CenaStana = 42000, ZgradaId = 2 },
              new Stan() { Id = 3, BrojStana = "501", TipStana = "Dvosoban", BrojKvadrata = 51, CenaStana = 47000, ZgradaId = 2 },
              new Stan() { Id = 4, BrojStana = "610", TipStana = "Dvosoban", BrojKvadrata = 75, CenaStana = 180000, ZgradaId = 3 },
              new Stan() { Id = 5, BrojStana = "610", TipStana = "Trosoban", BrojKvadrata = 114, CenaStana = 170000, ZgradaId = 1 }

          );
            base.OnModelCreating(modelBuilder);
        }
    }
}
