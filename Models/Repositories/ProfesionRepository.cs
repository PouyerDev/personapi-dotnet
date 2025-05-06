using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var existingProfesion = _context.Profesions.Find(profesion.Id);
            if (existingProfesion != null)
            {
                // Actualizamos las propiedades de la entidad existente
                _context.Entry(existingProfesion).CurrentValues.SetValues(profesion);
            }
            else
            {
                // Si no existe, la adjuntamos al contexto como modificada
                _context.Profesions.Attach(profesion);
                _context.Entry(profesion).State = EntityState.Modified;
            }
        }



        public void Delete(int id)
        {
            var profesion = _context.Profesions.Find(id);
            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
