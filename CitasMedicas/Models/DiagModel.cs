using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class DiagModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string valoracionEspecialista { get; set; } = string.Empty;
        public string enfermedad { get; set; } = string.Empty;

        // Relación con Cita
        public long cita_id { get; set; }
        public AppoModel cita { get; set; }
    }
}
