using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Psicologiaa.Model;
using Psicologiaa.Services;
namespace Psicologiaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionController : ControllerBase
    {

        private readonly IEvaluacionService _evaluacionService;

        public EvaluacionController(IEvaluacionService evaluacionService)
        {
            _evaluacionService = evaluacionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evaluacion>>> GetAll()
        {
            return Ok(await _evaluacionService.GetAllEvaluacion());
        }
        [HttpGet("{IdEvaluacion}")]
        public async Task<ActionResult<Evaluacion>> GetEvaluacion(int IdEvaluacion)
        {
            var Evaluacion = await _evaluacionService.GetEvaluacion(IdEvaluacion);
            if (Evaluacion == null)
            {
                return BadRequest("Informacion no encontrada");
            }
            return Ok(Evaluacion);
        }
        [HttpPost]
        public async Task<ActionResult<Evaluacion>> CreateEvaluacion([FromBody] Evaluacion evaluacion)
        {
            if (evaluacion == null)
            {
                return BadRequest("El objeto Evaluacion es nulo");
            }
            var newEvaluacion = await _evaluacionService.CreateEvaluacion(evaluacion.Fecha, evaluacion.TipoEvaluacion, evaluacion.Resultados);
            return Ok(newEvaluacion);
        }


        [HttpPut("{IdEvaluacion}")]

        public async Task<ActionResult<Evaluacion>> UpdateEvaluacion(int IdEvaluacion, [FromBody] Evaluacion Updateevaluacion)
        {
            if (Updateevaluacion == null || IdEvaluacion <= 0)
            {
                return BadRequest("Datos de entrada invalidos para actualizar Evaluacion");
            }
            var updateEvaluacion = await _evaluacionService.UpdateEvaluacion(IdEvaluacion, Updateevaluacion.Fecha, Updateevaluacion.TipoEvaluacion, Updateevaluacion.Resultados);
            return Ok(updateEvaluacion);

        }
        [HttpDelete("{IdEvaluacion}")]
        public async Task<ActionResult<Evaluacion>> DeleteEvaluacion(int IdEvaluacion)
        {
            if (IdEvaluacion <= 0)
            {
                return BadRequest("IdEvaluacion invalido para borrar");
            }
            var deletedEvaluacion = await _evaluacionService.DeleteEvaluacion(IdEvaluacion);
            return Ok(deletedEvaluacion);
        }

    }

}
