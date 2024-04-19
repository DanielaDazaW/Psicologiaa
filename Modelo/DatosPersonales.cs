using System.ComponentModel.DataAnnotations;

namespace Psicologiaa.Model
{
    public class DatosPersonales
    {
        [Key]
        public int IdDatos { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
    }
}