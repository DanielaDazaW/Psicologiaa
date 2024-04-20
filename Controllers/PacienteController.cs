using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicologiaa.Model;
using Psicologiaa.Services;

namespace Psicologiaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> GetAll()
        {
            return Ok(await _pacienteService.GetAllPaciente());
        }
        [HttpGet("{IdPaciente}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int IdPaciente)
        {
            var Paciente = await _pacienteService.GetPaciente(IdPaciente);
            if (Paciente == null)
            {
                return BadRequest("Informacion no encontrada");
            }
            return Ok(Paciente);
        }
        [HttpPost]
        public async Task<ActionResult<Paciente>> CreatePaciente([FromBody] Paciente paciente)
        {
            if (paciente == null)
            {
                return BadRequest("El objeto Paciente es nulo");
            }
            var newPaciente = await _pacienteService.CreatePaciente(paciente.Genero, paciente.IdDatos);
            return Ok(newPaciente);
        }


        [HttpPut("{IdPaciente}")]

        public async Task<ActionResult<Paciente>> UpdatePaciente(int IdPaciente, [FromBody] Paciente Updatepaciente)
        {
            if (Updatepaciente == null || IdPaciente <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Paciente");
            }
            var updatePaciente = await _pacienteService.UpdatePaciente(IdPaciente, Updatepaciente.Genero, Updatepaciente.IdDatos);
            return Ok(updatePaciente);

        }

        [HttpDelete("{IdPaciente}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(int IdPaciente)
        {
            if (IdPaciente <= 0)
            {
                return BadRequest("IdPaciente invalido para borrar");
            }
            var deletedPaciente = await _pacienteService.DeletePaciente(IdPaciente);
            return Ok(deletedPaciente);
        }

    }

}
