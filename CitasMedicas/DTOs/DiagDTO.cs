namespace CitasMedicas.DTOs
{
    public class DiagDTO
    {
        public long Id { get; set; }
        public string ValoracionEspecialista { get; set; } = string.Empty;
        public string Enfermedad { get; set; } = string.Empty;

        // Relación con Cita
        public long cita_id { get; set; }
    }
}
