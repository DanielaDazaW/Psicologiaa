using System.ComponentModel.DataAnnotations;

namespace Psicologiaa.Model
{
    public class Sesion
    {
        [Key]
        public int IdSesion { get; set; }
            public int IdPaciente { get; set; }
            public Paciente? Paciente { get; set; }


            public int IdEvaluacion { get; set; }
            public Evaluacion? Evaluacion { get; set; }
            //public required Terapeuta Terapeuta { get; set; }
            public DateOnly FechaInicio { get; set; }
            public DateOnly FechaFin { get; set; }
            public DateTime TiempoSesion { get; set; }
            public required string Notas { get; set; }
        }
    }

