
using System.Runtime.CompilerServices;
using Psicologia.Context;
using Microsoft.EntityFrameworkCore;
using System;
using Psicologiaa.Model;

namespace Psicologiaa.Repositorios
{
    public interface ISesionRepository
    {
        Task<List<Sesion>> GetAllSesion();
        Task<Sesion> GetSesion(int IdSesion);
        Task<Sesion> CreateSesion(int IdEvaluacion, DateOnly FechaInicio, DateOnly FechaFin, DateTime TiempoSesion, string Notas);
        Task<Sesion> UpdateSesion(Sesion sesion);
        Task<Sesion> DeleteSesion(Sesion sesion);
    }
    public class SesionRepository : ISesionRepository

    {
        private readonly EntidadesDbContext _db;
        public SesionRepository(EntidadesDbContext db)
        {
            _db = db;
        }
        public async Task<List<Sesion>> GetAllSesion()
        {
            return await _db.sesion.ToListAsync();
        }
        public async Task<Sesion> GetSesion(int IdSesion)
        {
            return await _db.sesion.FirstOrDefaultAsync(d => d.IdSesion == IdSesion);
        }
        public async Task<Sesion> CreateSesion(int IdEvaluacion, DateOnly FechaInicio, DateOnly FechaFin, DateTime TiempoSesion, string Notas)
        {
            Sesion newSesion = new Sesion
            {
                FechaInicio = FechaInicio,
                FechaFin = FechaFin,
                TiempoSesion = TiempoSesion,
                Notas = Notas,
                IdEvaluacion = IdEvaluacion,

            };
            await _db.sesion.AddAsync(newSesion);
            _db.SaveChanges();
            return newSesion;
        }
        public async Task<Sesion> UpdateSesion(Sesion sesion)
        {
            Sesion ConsultUpdate = await _db.sesion.FirstOrDefaultAsync(d => d.IdSesion == sesion.IdSesion);
            if (ConsultUpdate != null)
            {
                ConsultUpdate.FechaInicio= sesion.FechaInicio;
                ConsultUpdate.FechaFin = sesion.FechaFin;
                ConsultUpdate.TiempoSesion = sesion.TiempoSesion;
                ConsultUpdate.IdEvaluacion = sesion.IdEvaluacion;

                await _db.SaveChangesAsync();
            }
            return ConsultUpdate;
        }
        public async Task<Sesion> DeleteSesion(Sesion sesion)
        {
            await _db.sesion.AddAsync(sesion);
            _db.SaveChanges();

            return sesion;
        }

    }
}

    
