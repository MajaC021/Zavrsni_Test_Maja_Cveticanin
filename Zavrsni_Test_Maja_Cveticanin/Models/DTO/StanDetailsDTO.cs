using AutoMapper.Configuration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Zavrsni_Test_Maja_Cveticanin.Models.DTO
{
    public class StanDetailsDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Broj karaktera mora biti veci od 2, a manji od 100")]
        public string BrojStana { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Broj karaktera mora biti veci od 2, a manji od 20")]
        public string TipStana { get; set; }
        [Required]
        [Range(11, 300)]
        public int BrojKvadrata { get; set; }
        [Required]
        [Range(typeof(decimal), "10000", "300000")]
        public double CenaStana { get; set; }
        public string? ZgradaAdresa { get; set; }
        public int ZgradaId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is StanDetailsDTO dTO &&
                   Id == dTO.Id &&
                  BrojKvadrata == dTO.BrojKvadrata &&
                  TipStana == dTO.TipStana &&
                  BrojStana == dTO.BrojStana &&
                  CenaStana == dTO.CenaStana &&
                  ZgradaAdresa == dTO.ZgradaAdresa;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, BrojKvadrata, TipStana, BrojStana, CenaStana, ZgradaAdresa);
        }

    }
}
