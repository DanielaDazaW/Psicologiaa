
using Psicologiaa.Model;
using Psicologiaa.Repositorios;

namespace Psicologiaa.Services
{
        public interface IDatosPersonalesService
        {
            Task<List<DatosPersonales>> GetAllDatos();
            Task<DatosPersonales> GetDato(int IdDatos);
            Task<DatosPersonales> CreateDato(string Nombres, string Apellidos, string Email, string Telefono);
            Task<DatosPersonales> UpdateDato(int IdDatos, string Nombres, string Apellidos, string Email, string Telefono);
            Task<DatosPersonales> DeleteDato(int IdDatos);
        }
        public class DatosPersonalesService : IDatosPersonalesService
        {
        public readonly DatosPersonalesRepository _datosPersonalesRepository;
        public DatosPersonalesService (DatosPersonalesRepository datosPersonalesRepository)
        {
            _datosPersonalesRepository = datosPersonalesRepository;
        }
        public async Task<DatosPersonales> CreateDato(string Nombres, string Apellidos, string Email, string Telefono)
        {
            return await _datosPersonalesRepository.CreateDato(Nombres, Apellidos, Email, Telefono);
        }
        public async Task<List<DatosPersonales>> GetAllDatos()
        {
            return await _datosPersonalesRepository.GetAllDatos();
        }
        public async Task<DatosPersonales> GetDato(int IdDatos)
        {
            return await _datosPersonalesRepository.GetDato(IdDatos);
        }
        public async Task<DatosPersonales> UpdateDato(int IdDatos, string? Nombres=null, string? Apellidos = null, string? Email = null, string? Telefono = null)
        {
            DatosPersonales newDatosPersonales = await _datosPersonalesRepository.GetDato(IdDatos);
            if (newDatosPersonales != null) 
            {
                if (Nombres != null)
                {
                    newDatosPersonales.Nombres = Nombres;
                }
                if (Apellidos != null) 
                {
                    newDatosPersonales.Apellidos = Apellidos;
                }
                if (Email != null)
                {
                    newDatosPersonales.Email = Email;
                }
                if (Telefono != null)
                {
                    newDatosPersonales.Telefono = Telefono;
                }
            }
            return await _datosPersonalesRepository.UpdateDato(newDatosPersonales);
        }
        public async Task<DatosPersonales> DeleteDato(int IdDatos)
        {
            DatosPersonales datosPersonales = await _datosPersonalesRepository.GetDato(IdDatos);
            return await _datosPersonalesRepository.DeleteDato(datosPersonales);
        }

    }
}



