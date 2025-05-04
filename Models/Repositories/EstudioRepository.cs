using System.Collections.Generic;
using System.Linq;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Models.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
        }

        public Estudio? GetById(int idProf, int ccPer)
        {
            return _context.Estudios.Find(idProf, ccPer);
        }

        public void Add(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
        }

        public void Update(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
        }

        public void Delete(int idProf, int ccPer)
        {
            var estudio = _context.Estudios.Find(idProf, ccPer);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
