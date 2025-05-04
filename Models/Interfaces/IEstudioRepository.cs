using System.Collections.Generic;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Interfaces
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();
        Estudio? GetById(int idProf, int ccPer);
        void Add(Estudio estudio);
        void Update(Estudio estudio);
        void Delete(int idProf, int ccPer);
        void Save();
    }
}
