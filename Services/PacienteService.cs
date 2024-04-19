using Psicologiaa.Model;
using Psicologiaa.Repositorios;

namespace Psicologiaa.Services
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetAllPaciente();
        Task<Paciente> GetPaciente(int IdPaciente);
        Task<Paciente> CreatePaciente(string Genero, int IdDatos);
        Task<Paciente> UpdatePaciente(int IdPaciente, string? Genero=null, int? IdDatos=null);
        Task<Paciente> DeletePaciente(int IdPaciente);
    }
    public class PacienteService : IPacienteService
    {
        public readonly PacienteRepository _pacienteRepository;
        public PacienteService(PacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task<Paciente> CreatePaciente(string Genero, int IdDatos)
        {
            return await _pacienteRepository.CreatePaciente(Genero, IdDatos);
        }
        public async Task<List<Paciente>> GetAllPaciente()
        {
            return await _pacienteRepository.GetAllPaciente();
        }
        public async Task<Paciente> GetPaciente(int IdPaciente)
        {
            return await _pacienteRepository.GetPaciente(IdPaciente);
        }
        public async Task<Paciente> UpdatePaciente(int IdPaciente, string? Genero = null, int? IdDatos = null)
        {
            Paciente newPaciente = await _pacienteRepository.GetPaciente(IdPaciente);
            if (newPaciente != null)
            {
                if (Genero != null)
                {
                    newPaciente.Genero = Genero;
                }
                if (IdDatos != null)
                {
                    newPaciente.IdDatos = (int)IdDatos;
                }

                return await _pacienteRepository.UpdatePaciente(newPaciente);
            }
             throw new InvalidOperationException("Registro no encontrado");
        }
        public async Task<Paciente> DeletePaciente(int IdPaciente)
        {
            Paciente paciente = await _pacienteRepository.GetPaciente(IdPaciente);
            return await _pacienteRepository.DeletePaciente(paciente);
        }

        
    }
}