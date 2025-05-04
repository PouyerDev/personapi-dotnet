using System.Collections.Generic;
using System.Linq;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Models.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesion> GetAll()
        {
            return _context.Profesions.ToList();
        }

        public Profesion? GetById(int id)
        {
            return _context.Profesions.Find(id);
        }

        public void Add(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
        }

        public void Update(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
        }

        public void Delete(int id)
        {
            var profesion = _context.Profesions.Find(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
