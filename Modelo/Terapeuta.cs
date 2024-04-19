using System.ComponentModel.DataAnnotations;

namespace Psicologiaa.Model
{
    public class Terapeuta
    {
        [Key]
        public int IdTerapeuta { get; set; }
        public required string Especialidad { get; set; }
        public required int IdDatos { get; set; }
        public  DatosPersonales? DatosPersonales { get; set; }

    }
}
