using System.ComponentModel.DataAnnotations;

namespace Psicologiaa.Model
{
    public class Evaluacion
    {
            [Key]
            public int IdEvaluacion { get; set; }
            //public int IdPaciente { get; set; }
            ///public  Paciente? Paciente { get; set; }
            
            public DateOnly Fecha { get; set; }
            public required string TipoEvaluacion { get; set; }
            public required string Resultados { get; set; }

           // public int IdTerapeuta { get; set; }
          //  public required Terapeuta Terapeuta { get; set; }
    }
    }

