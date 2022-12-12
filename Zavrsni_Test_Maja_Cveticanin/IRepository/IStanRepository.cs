using Zavrsni_Test_Maja_Cveticanin.Models;
using Zavrsni_Test_Maja_Cveticanin.Models.filters;

namespace Zavrsni_Test_Maja_Cveticanin.IRepository
{
    public interface IStanRepository
    {
        IQueryable<Stan> GetAll();
        Stan GetById(int id);
        void Add(Stan glavna);
        void Update(Stan glavna);
        void Delete(Stan glavna);
        IQueryable<Stan> Filter(StanFilter stanFilter);
    }
}
