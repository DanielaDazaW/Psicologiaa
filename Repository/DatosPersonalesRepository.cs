
using System.Runtime.CompilerServices;
using Psicologia.Context;
using Microsoft.EntityFrameworkCore;
using Psicologiaa.Model;

namespace Psicologiaa.Repositorios
{
    public interface IDatosPersonalesRepository
    {
        Task <List<DatosPersonales>> GetAllDatos();
        Task <DatosPersonales> GetDato(int IdDatos);
        Task<DatosPersonales> CreateDato(string Nombres, string Apellidos, string Email, string Telefono);
        Task<DatosPersonales> UpdateDato(DatosPersonales datosPersonales);
        Task<DatosPersonales> DeleteDato(DatosPersonales datosPersonales);
    }
    public class DatosPersonalesRepository : IDatosPersonalesRepository

    {
        private readonly EntidadesDbContext _db;
        public DatosPersonalesRepository ( EntidadesDbContext db )
        {
            _db = db;
        }
        public async Task <List<DatosPersonales>> GetAllDatos()
        {
            return await _db.datosPersonales.ToListAsync();
        }
        public async Task <DatosPersonales> GetDato(int IdDatos)
        {
            return await _db.datosPersonales.FirstOrDefaultAsync(d=>d.IdDatos == IdDatos);
        }
        public async Task<DatosPersonales> CreateDato(string Nombres, string Apellidos, string Email, string Telefono)
        {
            DatosPersonales newDatosPersonales = new DatosPersonales 
            { 
                Nombres = Nombres, Apellidos = Apellidos, Email = Email, Telefono = Telefono
            };
            await _db.datosPersonales.AddAsync(newDatosPersonales);
            _db.SaveChanges();
            return newDatosPersonales;
        }
        public async Task<DatosPersonales> UpdateDato(DatosPersonales datosPersonales)
        {
          DatosPersonales ConsultUpdate = await _db.datosPersonales.FindAsync(datosPersonales.IdDatos);
            {
                if (ConsultUpdate != null) 
                {
                    ConsultUpdate.Nombres = datosPersonales.Nombres;
                    ConsultUpdate.Apellidos = datosPersonales.Apellidos;
                    ConsultUpdate.Email = datosPersonales.Email;
                    ConsultUpdate.Telefono = datosPersonales.Telefono;
                    await _db.SaveChangesAsync();
                }
                return datosPersonales;
            }

        
     
    }
        public async Task<DatosPersonales> DeleteDato(DatosPersonales datosPersonales)
        {
            await _db.datosPersonales.AddAsync(datosPersonales);
            _db.SaveChanges();

            return datosPersonales;
        }
    }
}

