using Zavrsni_Test_Maja_Cveticanin.Models;

namespace Zavrsni_Test_Maja_Cveticanin.IRepository
{
    public interface IZgradaRepository
    {
        IEnumerable<Zgrada> GetAll();
        Zgrada GetById(int id);
        void Add(Zgrada field);
        void Update(Zgrada field);
        void Delete(Zgrada field);
       // IQueryable<Sporedna> Search(int field);
    }
}
