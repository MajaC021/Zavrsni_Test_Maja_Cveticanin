using AutoMapper;
using Zavrsni_Test_Maja_Cveticanin.Models.DTO;

namespace Zavrsni_Test_Maja_Cveticanin.Models.Profil
{
    public class StanProfil : Profile
    {
        public StanProfil()
        {
            CreateMap<Stan, StanDTO>();
            CreateMap<Stan, StanDetailsDTO>();
        }
    }
}
