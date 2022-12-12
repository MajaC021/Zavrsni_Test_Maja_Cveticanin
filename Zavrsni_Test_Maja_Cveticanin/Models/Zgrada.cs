using System.ComponentModel.DataAnnotations;

namespace Zavrsni_Test_Maja_Cveticanin.Models
{
    public class Zgrada
    {
        public int Id { get; set; }
        [Required]
        [StringLength(120, ErrorMessage = "Broj karaktera mora biti manja od 120")]
        public string Adresa { get; set; }
        [Range(1930, 2022, ErrorMessage = "Godina mora biti manja od 2022, a veca ili jednaka sa 1930")]
        public int GodinaIzgradnje { get; set; }
    }
}
