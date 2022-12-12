using System.ComponentModel.DataAnnotations;

namespace Zavrsni_Test_Maja_Cveticanin.Models.DTO
{
    public class StanDTO
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
    }
}
