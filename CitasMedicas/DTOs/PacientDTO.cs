namespace CitasMedicas.DTOs
{
    public class PacientDTO:UserDTO
    {
        public string Nss { get; set; } = string.Empty;
        public string NumTarjeta { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

    }
}
