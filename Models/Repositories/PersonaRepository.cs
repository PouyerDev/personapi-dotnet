using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Models.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        public Persona? GetById(int cc)
        {
            return _context.Personas.Find(cc);
        }

        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void Update(Persona persona)
        {
            var existingPersona = _context.Personas.Find(persona.Cc);
            if (existingPersona != null)
            {
                // Actualizamos las propiedades de la entidad existente
                _context.Entry(existingPersona).CurrentValues.SetValues(persona);
            }
            else
            {
                // Si no existe, la adjuntamos al contexto como modificada
                _context.Personas.Attach(persona);
                _context.Entry(persona).State = EntityState.Modified;
            }
        }


        public void Delete(int cc)
        {
            var persona = _context.Personas.Find(cc);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
