using System.Collections.Generic;
using System.Linq;
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
            _context.Telefonos.Update(telefono);
        }

        public void Delete(string num)
        {
            var telefono = _context.Telefonos.Find(num);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
