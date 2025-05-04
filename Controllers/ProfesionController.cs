using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var profesiones = _profesionRepository.GetAll();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var profesion = _profesionRepository.GetById(id);
            if (profesion == null)
                return NotFound();
            return Ok(profesion);
        }

        [HttpPost]
        public IActionResult Create(Profesion profesion)
        {
            _profesionRepository.Add(profesion);
            _profesionRepository.Save();
            return CreatedAtAction(nameof(GetById), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Profesion profesion)
        {
            if (id != profesion.Id)
                return BadRequest();

            var existingProfesion = _profesionRepository.GetById(id);
            if (existingProfesion == null)
                return NotFound();

            _profesionRepository.Update(profesion);
            _profesionRepository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var profesion = _profesionRepository.GetById(id);
            if (profesion == null)
                return NotFound();

            _profesionRepository.Delete(id);
            _profesionRepository.Save();
            return NoContent();
        }
    }
}
