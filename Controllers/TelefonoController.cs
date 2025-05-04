using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Interfaces;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var telefonos = _telefonoRepository.GetAll();
            return Ok(telefonos);
        }

        [HttpGet("{num}")]
        public IActionResult GetById(string num)
        {
            var telefono = _telefonoRepository.GetById(num);
            if (telefono == null)
                return NotFound();
            return Ok(telefono);
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            _telefonoRepository.Add(telefono);
            _telefonoRepository.Save();
            return CreatedAtAction(nameof(GetById), new { num = telefono.Num }, telefono);
        }

        [HttpPut("{num}")]
        public IActionResult Update(string num, Telefono telefono)
        {
            if (num != telefono.Num)
                return BadRequest();

            var existingTelefono = _telefonoRepository.GetById(num);
            if (existingTelefono == null)
                return NotFound();

            _telefonoRepository.Update(telefono);
            _telefonoRepository.Save();
            return NoContent();
        }

        [HttpDelete("{num}")]
        public IActionResult Delete(string num)
        {
            var telefono = _telefonoRepository.GetById(num);
            if (telefono == null)
                return NotFound();

            _telefonoRepository.Delete(num);
            _telefonoRepository.Save();
            return NoContent();
        }
    }
}
