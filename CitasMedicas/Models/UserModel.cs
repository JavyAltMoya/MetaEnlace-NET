using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicas.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string nombre { get; set; } = string.Empty;
        public string apellidos { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public string clave { get; set; } = string.Empty;

    }
}
