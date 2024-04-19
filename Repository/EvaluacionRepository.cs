
using System.Runtime.CompilerServices;
using Psicologia.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Psicologiaa.Model;

namespace Psicologiaa.Repositorios
{
    public interface IEvaluacionRepository
    {
        Task<List<Evaluacion>> GetAllEvaluacion();
        Task<Evaluacion> GetEvaluacion(int IdEvaluacion);
        Task<Evaluacion> CreateEvaluacion(DateOnly Fecha, string TipoEvaluacion, string Resultados);
        Task<Evaluacion> UpdateEvaluacion(Evaluacion evaluacion);
        Task<Evaluacion> DeleteEvaluacion(Evaluacion evaluacion);
    }
    public class EvaluacionRepository : IEvaluacionRepository

    {
        private readonly EntidadesDbContext _db;
        public EvaluacionRepository(EntidadesDbContext db)
        {
            _db = db;
        }
        public async Task<List<Evaluacion>> GetAllEvaluacion()
        {
            return await _db.evaluacion.ToListAsync();
        }
        public async Task<Evaluacion> GetEvaluacion(int IdEvaluacion)
        {
            return await _db.evaluacion.FirstOrDefaultAsync(d => d.IdEvaluacion == IdEvaluacion);
        }
        public async Task<Evaluacion> CreateEvaluacion(DateOnly Fecha, string TipoEvaluacion, string Resultados)
        {
            Evaluacion newEvaluacion = new Evaluacion
            {
                Fecha = Fecha,
                TipoEvaluacion = TipoEvaluacion,
                Resultados = Resultados
            };
            await _db.evaluacion.AddAsync(newEvaluacion);
            _db.SaveChanges();
            return newEvaluacion;
        }
        public async Task<Evaluacion> UpdateEvaluacion(Evaluacion evaluacion)
        {
            Evaluacion ConsultUpdate = await _db.evaluacion.FirstOrDefaultAsync(d => d.IdEvaluacion == evaluacion.IdEvaluacion);
            if (ConsultUpdate != null)
            {
            ConsultUpdate.Fecha = evaluacion.Fecha;
            ConsultUpdate.TipoEvaluacion = evaluacion.TipoEvaluacion;
            ConsultUpdate.Resultados = evaluacion.Resultados;

           await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }
        public async Task<Evaluacion> DeleteEvaluacion(Evaluacion evaluacion)
         {
        await _db.evaluacion.AddAsync(evaluacion);
        _db.SaveChanges();

        return evaluacion;
        }

    }
}