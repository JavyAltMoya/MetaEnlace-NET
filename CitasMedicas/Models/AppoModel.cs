using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class AppoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public DateTime fechaHora { get; set; }
        public string motivoCita { get; set; } = string.Empty;
        public int attribute11 { get; set; }

        // Relación con Paciente
        public long paciente_id { get; set; }
        public PacientModel paciente { get; set; }

        // Relación con Medico
        public long medico_id { get; set; }
        public MedicModel medico { get; set; }

        // Relación con Diagnóstico
        public DiagModel diagnostico { get; set; }
    }
}
