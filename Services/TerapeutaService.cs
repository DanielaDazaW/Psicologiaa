using Psicologiaa.Model;

using Psicologiaa.Repositorios;

namespace Psicologiaa.Services
{
    public interface ITerapeutaService
    {
        Task<List<Terapeuta>> GetAllTerapeuta();
        Task<Terapeuta> GetTerapeuta(int IdTerapeuta);
        Task<Terapeuta> CreateTerapeuta(string Especialidad, int IdDatos);
        Task<Terapeuta> UpdateTerapeuta(int IdTerapeuta, string? Especialidad=null, int? IdDatos=null);
        Task<Terapeuta> DeleteTerapeuta(int IdTerapeuta);
    }
    public class TerapeutaService : ITerapeutaService
    {
        public readonly TerapeutaRepository _terapeutaRepository;
        public TerapeutaService(TerapeutaRepository terapeutaRepository)
        {
            _terapeutaRepository = terapeutaRepository;
        }
        public async Task<Terapeuta> CreateTerapeuta(string Especialidad, int IdDatos)
        {
            return await _terapeutaRepository.CreateTerapeuta(Especialidad, IdDatos);
        }
        public async Task<List<Terapeuta>> GetAllTerapeuta()
        {
            return await _terapeutaRepository.GetAllTerapeuta();
        }
        public async Task<Terapeuta> GetTerapeuta(int IdTerapeuta)
        {
            return await _terapeutaRepository.GetTerapeuta(IdTerapeuta);
        }
        public async Task<Terapeuta> UpdateTerapeuta(int IdTerapeuta, string? Especialidad = null, int? IdDatos = null)
        {
            Terapeuta newTerapeuta = await _terapeutaRepository.GetTerapeuta(IdTerapeuta);
            
            if (newTerapeuta != null)
            {
                if (Especialidad != null)
                {
                    newTerapeuta.Especialidad = Especialidad;
                }
                if (IdDatos != null)
                {
                    newTerapeuta.IdDatos = (int)IdDatos;
                }
                return await _terapeutaRepository.UpdateTerapeuta(newTerapeuta);
            }
            throw new InvalidOperationException("Registro no encontrado");
        }
        public async Task<Terapeuta> DeleteTerapeuta(int IdTerapeuta)
        {
            Terapeuta terapeuta = await _terapeutaRepository.GetTerapeuta(IdTerapeuta);
            return await _terapeutaRepository.DeleteTerapeuta(terapeuta);
        }

    }
}