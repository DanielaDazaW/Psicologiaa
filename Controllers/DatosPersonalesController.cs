using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Psicologiaa.Model;
using Psicologiaa.Services;

namespace Psicologiaa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPersonalesController : ControllerBase
    {
        private readonly IDatosPersonalesService _datosPersonalesService;
        public DatosPersonalesController(IDatosPersonalesService datosPersonalesService)
        {
            _datosPersonalesService = datosPersonalesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DatosPersonales>>> GetAllDatos()
        {
            return Ok(await _datosPersonalesService.GetAllDatos());
        }
        [HttpGet("{IdDato}")]
        public async Task<ActionResult<DatosPersonales>> GetDato(int IdDatos)
        {
            var datosPersonales = await _datosPersonalesService.GetDato(IdDatos);
            if (datosPersonales == null)
            {
                return BadRequest("Datos personalees not found");
            }
            return Ok(datosPersonales);
        }
        [HttpPost]
        public async Task<ActionResult<DatosPersonales>> CreateDato([FromBody] DatosPersonales datosPersonales)
        {
            if (datosPersonales == null)
            {
                return BadRequest ("El objeto Datos Personales es nulo");
            }
            var newDato = await _datosPersonalesService.CreateDato(datosPersonales.Nombres, datosPersonales.Apellidos, datosPersonales.Email, datosPersonales.Telefono);
            return Ok(newDato);
        }


        [HttpPut("{IdDato}")]

        public async Task <ActionResult<DatosPersonales>> UpdateDato (int IdDatos, [FromBody]DatosPersonales UpdatedatosPersonales)
        {
            if (UpdatedatosPersonales == null || IdDatos <= 0) 
            {
                return BadRequest("Datos de entrada invalidos para actualizar Datos Personales");
            }
            var datosPersonalesU = await _datosPersonalesService.UpdateDato(IdDatos, UpdatedatosPersonales.Nombres, UpdatedatosPersonales.Apellidos, UpdatedatosPersonales.Email, UpdatedatosPersonales.Telefono);
            return Ok(datosPersonalesU);

        }
        [HttpDelete("{IdDato}")]
        public async Task <ActionResult<DatosPersonales>> DeleteDato (int IdDato)
        {
            if (IdDato <=0)
            {
                return BadRequest("IdDato invalido para borrar");
            }
            var deletedDato = await _datosPersonalesService.DeleteDato(IdDato);
            return Ok(deletedDato);
        }

    }

}



