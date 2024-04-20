using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicologiaa.Model;
using Psicologiaa.Services;

namespace Psicologiaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerapeutaController : ControllerBase
        {
    
        private readonly ITerapeutaService _terapeutaService;

    public TerapeutaController(ITerapeutaService terapeutaService)
        {
            _terapeutaService = terapeutaService;
        }

    [HttpGet]
    public async Task<ActionResult<List<Terapeuta>>> GetAll()
        {
            return Ok(await _terapeutaService.GetAllTerapeuta());
        }
    [HttpGet("{IdPaciente}")]
    public async Task<ActionResult<Terapeuta>> GetTerapeuta(int IdTerapeuta)
    {
        var Terapeuta = await _terapeutaService.GetTerapeuta(IdTerapeuta);
        if (Terapeuta == null)
        {
            return BadRequest("Informacion no encontrada");
        }
        return Ok(Terapeuta);
    }
    [HttpPost]
    public async Task<ActionResult<Terapeuta>> CreateTerapeuta([FromBody] Terapeuta terapeuta)
    {
        if (terapeuta == null)
        {
            return BadRequest("El objeto Terapeuta es nulo");
        }
        var newTerapeuta = await _terapeutaService.CreateTerapeuta(terapeuta.Especialidad, terapeuta.IdDatos);
        return Ok(newTerapeuta);
    }


    [HttpPut("{IdTerapeuta}")]

    public async Task<ActionResult<Terapeuta>> UpdateTerapeuta(int IdTerapeuta, [FromBody] Terapeuta Updateterapeuta)
    {
        if (Updateterapeuta == null || IdTerapeuta <= 0)
        {
            return BadRequest("Datos de entrada invalidos para actualizar Terapeuta");
        }
        var updateTerapeuta = await _terapeutaService.UpdateTerapeuta(IdTerapeuta, Updateterapeuta.Especialidad, Updateterapeuta.IdDatos);
        return Ok(updateTerapeuta);

    }

    [HttpDelete("{IdTerapeuta}")]
    public async Task<ActionResult<Terapeuta>> DeleteTerapeuta(int IdTerapeuta)
    {
        if (IdTerapeuta <= 0)
        {
            return BadRequest("IdTerapeuta invalido para borrar");
        }
        var deletedTerapeuta = await _terapeutaService.DeleteTerapeuta(IdTerapeuta);
        return Ok(deletedTerapeuta);
    }

    }

}