using System.ComponentModel.DataAnnotations;

namespace Psicologiaa.Model
{
    public class Paciente
    {
        [Key]

        public int IdPaciente { get; set; }
        public  string Genero { get; set; }

        public required int IdDatos { get; set; }

        public  DatosPersonales? DatosPersonales { get; set; }
    }
}
