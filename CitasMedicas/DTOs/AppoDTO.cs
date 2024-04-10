namespace CitasMedicas.DTOs
{
    public class AppoDTO
    {
        public long Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; } = string.Empty;
        public int Attribute11 { get; set; }

        // Relación con Paciente
        public long paciente_id { get; set; }

        // Relación con Medico
        public long medico_id { get; set; }

    }
}
