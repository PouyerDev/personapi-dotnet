using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var personas = _personaRepository.GetAll();
            return Ok(personas);
        }

        [HttpGet("{cc}")]
        public IActionResult GetById(int cc)
        {
            var persona = _personaRepository.GetById(cc);
            if (persona == null)
                return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            _personaRepository.Add(persona);
            _personaRepository.Save();
            return CreatedAtAction(nameof(GetById), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        public IActionResult Update(int cc, Persona persona)
        {
            if (cc != persona.Cc)
                return BadRequest();

            var existingPersona = _personaRepository.GetById(cc);
            if (existingPersona == null)
                return NotFound();

            _personaRepository.Update(persona);
            _personaRepository.Save();
            return NoContent();
        }

        [HttpDelete("{cc}")]
        public IActionResult Delete(int cc)
        {
            var persona = _personaRepository.GetById(cc);
            if (persona == null)
                return NotFound();

            _personaRepository.Delete(cc);
            _personaRepository.Save();
            return NoContent();
        }
    }
}
