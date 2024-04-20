
using Psicologiaa.Model;
using Psicologiaa.Repositorios;

namespace Psicologiaa.Services
{
    public interface IEvaluacionService
    {
        Task<List<Evaluacion>> GetAllEvaluacion();
        Task<Evaluacion> GetEvaluacion(int IdEvaluacion);
        Task<Evaluacion> CreateEvaluacion( DateOnly Fecha, string TipoEvaluacion, string Resultados);
        Task<Evaluacion> UpdateEvaluacion(int IdEvaluacion, DateOnly? Fecha = null, string? TipoEvaluacion = null, string? Resultados = null);
        Task<Evaluacion> DeleteEvaluacion(int IdEvaluacion);
    }
    public class EvaluacionService : IEvaluacionService
    {
        public readonly IEvaluacionRepository _evaluacionRepository;
        public EvaluacionService(IEvaluacionRepository evaluacionRepository)
        {
            _evaluacionRepository = evaluacionRepository;
        }
        public async Task<Evaluacion> CreateEvaluacion( DateOnly Fecha, string TipoEvaluacion, string Resultados)
        {
            return await _evaluacionRepository.CreateEvaluacion( Fecha, TipoEvaluacion, Resultados);
        }
        public async Task<List<Evaluacion>> GetAllEvaluacion()
        {
            return await _evaluacionRepository.GetAllEvaluacion();
        }
        public async Task<Evaluacion> GetEvaluacion(int IdEvaluacion)
        {
            return await _evaluacionRepository.GetEvaluacion(IdEvaluacion);
        }
        public async Task<Evaluacion> UpdateEvaluacion(int IdEvaluacion, DateOnly? Fecha = null, string? TipoEvaluacion = null, string? Resultados = null)
        {
            Evaluacion newEvaluacion = await _evaluacionRepository.GetEvaluacion(IdEvaluacion);
            
            if (newEvaluacion != null)
            {
                if (TipoEvaluacion != null)
                {
                    newEvaluacion.TipoEvaluacion = TipoEvaluacion;
                }
                if (Resultados != null)
                {
                    newEvaluacion.Resultados = Resultados;
                }
                if (Fecha != null)
                {
                    newEvaluacion.Fecha = (DateOnly) Fecha;
                }
                return await _evaluacionRepository.UpdateEvaluacion(newEvaluacion);
            }
                throw new InvalidOperationException("Registro no encontrado");
        }
        public async Task<Evaluacion> DeleteEvaluacion(int IdEvaluacion)
        {
            Evaluacion evaluacion = await _evaluacionRepository.GetEvaluacion(IdEvaluacion);
            return await _evaluacionRepository.DeleteEvaluacion(evaluacion);
        }

    }
}