using Microsoft.EntityFrameworkCore;
using Psicologiaa.Model;



namespace Psicologia.Context
{
    public class EntidadesDbContext : DbContext

    {
        public EntidadesDbContext(DbContextOptions<EntidadesDbContext> options) : base(options)
        {
        }

        public DbSet<DatosPersonales> datosPersonales { get; set; } = null!;
        public DbSet<Evaluacion> evaluacion { get; set; } = null!;
        public DbSet<Paciente> paciente { get; set; } = null!;
        public DbSet<Sesion> sesion { get; set; } = null!;
        public DbSet<Terapeuta> terapeuta { get; set; } = null!;
       // public DbSet<Usuario> Usuarios { get; set; } = null!;
        //public DbSet<Rol> Roles { get; set; }


    }
}