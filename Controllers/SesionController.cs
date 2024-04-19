using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicologiaa.Model;
using Psicologiaa.Services;

namespace Psicologiaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {

        private readonly SesionService _sesionService;
        public SesionController(SesionService SesionService)
        {
            _sesionService = SesionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sesion>>> GetAll()
        {
            return Ok(await _sesionService.GetAllSesion());
        }
        [HttpGet("{IdSesion}")]
        public async Task<ActionResult<Sesion>> GetSesion(int IdSesion)
        {
            var Sesion = await _sesionService.GetSesion(IdSesion);
            if (Sesion == null)
            {
                return BadRequest("Informacion no encontrada");
            }
            return Ok(Sesion);
        }
        [HttpPost]
        public async Task<ActionResult<Sesion>> CreateSesion([FromBody] Sesion sesion)
        {
            if (sesion == null)
            {
                return BadRequest("El objeto Sesion es nulo");
            }
            var newSesion = await _sesionService.CreateSesion(sesion.FechaInicio, sesion.FechaFin, sesion.TiempoSesion, sesion.Notas);
            return Ok(newSesion);
        }


        [HttpPut("{IdSesion}")]

        public async Task<ActionResult<Sesion>> UpdateSesion(int IdSesion, [FromBody] Sesion Updatesesion)
        {
            if (UpdateSesion == null || IdSesion <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Sesion");
            }
            var updateSesion = await _sesionService.UpdateSesion(IdSesion, Updatesesion.FechaInicio, Updatesesion.FechaFin, Updatesesion.TiempoSesion, Updatesesion.Notas);
            return Ok(updateSesion);

        }

        [HttpDelete("{IdSesion}")]
        public async Task<ActionResult<Sesion>> DeleteSesion(int IdSesion)
        {
            if (IdSesion <= 0)
            {
                return BadRequest("IdSesion invalido para borrar");
            }
            var deletedSesion = await _sesionService.DeleteSesion(IdSesion);
            return Ok(deletedSesion);
        }

    }

}

