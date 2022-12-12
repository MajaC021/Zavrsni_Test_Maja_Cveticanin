using Microsoft.EntityFrameworkCore;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Models;
using Zavrsni_Test_Maja_Cveticanin.Models.Context;

namespace Zavrsni_Test_Maja_Cveticanin.Repository
{
    public class ZgradaRepository : IZgradaRepository
    {
        private readonly AppDbContext _context;

        public ZgradaRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Add(Zgrada field)
        {
            _context.Zgrade.Add(field);
            _context.SaveChanges();
        }

        public void Delete(Zgrada field)
        {
            _context.Zgrade.Remove(field);
            _context.SaveChanges();
        }

        public IEnumerable<Zgrada> GetAll()
        {
            return _context.Zgrade;
        }

        public Zgrada GetById(int id)
        {
            return _context.Zgrade.FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Zgrada> Search(int field)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Sporedna> Search(int field)
        //{
        //    return _context.Zgrade.Where(x => x. >= ).OrderBy(x => x.);
        //}

        public void Update(Zgrada field)
        {
            _context.Entry(field).State = EntityState.Modified;

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
