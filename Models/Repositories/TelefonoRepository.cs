using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Models.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Telefono> GetAll()
        {
            return _context.Telefonos.ToList();
        }

        public Telefono? GetById(string num)
        {
            return _context.Telefonos.Find(num);
        }

        public void Add(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
        }

        public void Update(Telefono telefono)
        {
            var existingTelefono = _context.Telefonos.Find(telefono.Num);
            if (existingTelefono != null)
            {
                _context.Entry(existingTelefono).CurrentValues.SetValues(telefono);
            }
            else
            {
                _context.Telefonos.Attach(telefono);
                _context.Entry(telefono).State = EntityState.Modified;
            }
        }

        public void Delete(string num)
        {
            var telefono = _context.Telefonos.Find(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
