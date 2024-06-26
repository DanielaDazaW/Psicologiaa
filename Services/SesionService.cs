﻿
using Psicologiaa.Model;
using Psicologiaa.Repositorios;

namespace Psicologiaa.Services
{
    public interface ISesionService
    {
        Task<List<Sesion>> GetAllSesion();
        Task<Sesion> GetSesion(int IdSesion);
        Task<Sesion> CreateSesion(int IdEvaluacion, DateOnly FechaInicio, DateOnly FechaFin, DateTime TiempoSesion, string Notas);
        Task<Sesion> UpdateSesion(int IdSesion, int? IdEvaluacion =null, DateOnly? FechaInicio=null, DateOnly? FechaFin= null, DateTime? TiempoSesion= null, string? Notas=null);
        Task<Sesion> DeleteSesion(int IdSesion);
    }
    public class SesionService : ISesionService
    {
        public readonly ISesionRepository _sesionRepository;
        public SesionService(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;
        }
        public async Task<Sesion> CreateSesion(int IdEvaluacion, DateOnly FechaInicio, DateOnly FechaFin, DateTime TiempoSesion, string Notas)
        {
            return await _sesionRepository.CreateSesion(IdEvaluacion, FechaInicio, FechaFin, TiempoSesion, Notas);
        }
        public async Task<List<Sesion>> GetAllSesion()
        {
            return await _sesionRepository.GetAllSesion();
        }
        public async Task<Sesion> GetSesion(int IdSesion)
        {
            return await _sesionRepository.GetSesion(IdSesion);
        }
        public async Task<Sesion> UpdateSesion(int IdSesion, int? IdEvaluacion = null, DateOnly? FechaInicio = null, DateOnly? FechaFin = null, DateTime? TiempoSesion = null, string? Notas = null)
        {
            Sesion newSesion = await _sesionRepository.GetSesion(IdSesion);

            if (newSesion != null)
            {
                if (Notas != null)
                {
                    newSesion.Notas = Notas;
                }
                if (FechaInicio != null)
                {
                    newSesion.FechaInicio = (DateOnly)FechaInicio;
                }
                if (FechaFin != null)
                {
                    newSesion.FechaFin = (DateOnly)FechaFin;
                }
                if (TiempoSesion != null)
                {
                    newSesion.TiempoSesion = (DateTime)TiempoSesion;
                }
                if (IdEvaluacion != null)
                {
                    newSesion.IdEvaluacion = (int)IdEvaluacion;
                }
                return await _sesionRepository.UpdateSesion(newSesion);

            }
            throw new InvalidOperationException("Registro no encontrado");
        }
        public async Task<Sesion> DeleteSesion(int IdSesion)
        {
            Sesion sesion = await _sesionRepository.GetSesion(IdSesion);
            return await _sesionRepository.DeleteSesion(sesion);
        }
    }
}