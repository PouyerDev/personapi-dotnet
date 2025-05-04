using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudioController : ControllerBase
    {
        private readonly IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var estudios = _estudioRepository.GetAll();
            return Ok(estudios);
        }

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetById(int idProf, int ccPer)
        {
            var estudio = _estudioRepository.GetById(idProf, ccPer);
            if (estudio == null)
                return NotFound();
            return Ok(estudio);
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            _estudioRepository.Add(estudio);
            _estudioRepository.Save();
            return CreatedAtAction(nameof(GetById), new { idProf = estudio.IdProf, ccPer = estudio.CcPer }, estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult Update(int idProf, int ccPer, Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
                return BadRequest();

            var existingEstudio = _estudioRepository.GetById(idProf, ccPer);
            if (existingEstudio == null)
                return NotFound();

            _estudioRepository.Update(estudio);
            _estudioRepository.Save();
            return NoContent();
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _estudioRepository.GetById(idProf, ccPer);
            if (estudio == null)
                return NotFound();

            _estudioRepository.Delete(idProf, ccPer);
            _estudioRepository.Save();
            return NoContent();
        }
    }
}
