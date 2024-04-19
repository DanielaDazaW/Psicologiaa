

using Psicologia.Context;
using Microsoft.EntityFrameworkCore;
using Psicologiaa.Model;

namespace Psicologiaa.Repositorios
{
    public interface ITerapeutaRepository
    {
        Task <List<Terapeuta>> GetAllTerapeuta();
        Task<Terapeuta> GetTerapeuta(int IdTerapeuta);
        Task<Terapeuta> CreateTerapeuta(string Especialidad, int IdDatos);
        Task<Terapeuta> UpdateTerapeuta(Terapeuta terapeuta);
        Task<Terapeuta> DeleteTerapeuta(Terapeuta terapeuta);
    }
    public class TerapeutaRepository : ITerapeutaRepository

    {
        private readonly EntidadesDbContext _db;
        public TerapeutaRepository(EntidadesDbContext db)
        {
            _db = db;
        }
        public async Task<List<Terapeuta>> GetAllTerapeuta()
        {
            return await _db.terapeuta.ToListAsync();
        }
        public async Task<Terapeuta> GetTerapeuta(int IdTerapeuta)
        {
            return await _db.terapeuta.FirstOrDefaultAsync(d => d.IdTerapeuta == IdTerapeuta);
        }
        public async Task<Terapeuta> CreateTerapeuta(string Especialidad, int IdDatos)
        {
            Terapeuta newTerapeuta = new Terapeuta
            {
                Especialidad = Especialidad,
                 
                IdDatos = IdDatos
            };
            await _db.terapeuta.AddAsync(newTerapeuta);
            _db.SaveChanges();
            return newTerapeuta;
        }
        public async Task<Terapeuta> UpdateTerapeuta(Terapeuta terapeuta)
        {

            Terapeuta ConsultUpdate = await _db.terapeuta.FirstOrDefaultAsync(d => d.IdTerapeuta == terapeuta.IdTerapeuta);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.Especialidad= terapeuta.Especialidad;
                ConsultUpdate.IdDatos = terapeuta.IdDatos;
                

                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;

        }
        public async Task<Terapeuta> DeleteTerapeuta(Terapeuta terapeuta)
        {
            await _db.terapeuta.AddAsync(terapeuta);
            _db.SaveChanges();

            return terapeuta;
        }
    }
}
