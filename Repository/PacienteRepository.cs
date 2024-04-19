
using System.Runtime.CompilerServices;
using Psicologia.Context;
using Microsoft.EntityFrameworkCore;
using Psicologiaa.Model;

namespace Psicologiaa.Repositorios
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAllPaciente();
        Task<Paciente> GetPaciente(int IdPaciente);
        Task<Paciente> CreatePaciente(string Genero, int IdDatos);
        Task<Paciente> UpdatePaciente(Paciente paciente);
        Task<Paciente> DeletePaciente(Paciente paciente);
    }
    public class PacienteRepository : IPacienteRepository

    {
        private readonly EntidadesDbContext _db;
        public PacienteRepository(EntidadesDbContext db)
        {
            _db = db;
        }
        public async Task<List<Paciente>> GetAllPaciente()
        {
            return await _db.paciente.ToListAsync();
        }
        public async Task<Paciente> GetPaciente(int IdPaciente)
        {
            return await _db.paciente.FirstOrDefaultAsync(d => d.IdPaciente == IdPaciente);
        }
        public async Task<Paciente> CreatePaciente(string Genero, int IdDatos)
        {
            Paciente newPaciente = new Paciente
            {
                Genero = Genero
                 ,
                IdDatos = IdDatos
            };
            await _db.paciente.AddAsync(newPaciente);
            _db.SaveChanges();
            return newPaciente;
        }
        public async Task<Paciente> UpdatePaciente(Paciente paciente)
        {
            Paciente ConsultUpdate = await _db.paciente.FirstOrDefaultAsync(d => d.IdPaciente == paciente.IdPaciente);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Genero = paciente.Genero;
                ConsultUpdate.IdDatos = paciente.IdDatos;

                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }
        public async Task<Paciente> DeletePaciente(Paciente paciente)
        {
            await _db.paciente.AddAsync(paciente);
            _db.SaveChanges();

            return paciente;
        }

    }
}