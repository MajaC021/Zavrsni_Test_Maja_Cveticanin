using Microsoft.EntityFrameworkCore;
using System.Linq;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Models;
using Zavrsni_Test_Maja_Cveticanin.Models.Context;
using Zavrsni_Test_Maja_Cveticanin.Models.filters;

namespace Zavrsni_Test_Maja_Cveticanin.Repository
{
    public class StanRepository : IStanRepository
    {
        private readonly AppDbContext _context;
        public StanRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Add(Stan glavna)
        {
            _context.Stanovi.Add(glavna);
            _context.SaveChanges();
        }

        public void Delete(Stan glavna)
        {
            _context.Stanovi.Remove(glavna);
            _context.SaveChanges();
        }

        public IQueryable<Stan> Filter(StanFilter stanFilter)
        {
            var results = _context.Stanovi.Include("Zgrada").Where(entry => entry.CenaStana >= stanFilter.MinCena && entry.CenaStana <= stanFilter.MaxCena).OrderByDescending(x => x.CenaStana).AsQueryable();
            return results;
        }


        public IQueryable<Stan> GetAll()
        {
            return _context.Stanovi;
        }

        public Stan GetById(int id)
        {
            Stan selsShop = _context.Stanovi.Include(c => c.Zgrada).FirstOrDefault(c => c.Id == id);
            return _context.Stanovi.FirstOrDefault(p => p.Id == selsShop.Id);
        }

        public void Update(Stan glavna)
        {
            _context.Entry(glavna).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
