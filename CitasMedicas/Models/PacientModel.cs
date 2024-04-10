namespace CitasMedicas.Models
{
    public class PacientModel:UserModel
    {
        public string nss { get; set; } = string.Empty;
        public string numTarjeta { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;

        public List<AppoModel> citas { get; set; }
        public List<MedicModel> medicos { get; set; }
    }
}
