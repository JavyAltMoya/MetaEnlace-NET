namespace CitasMedicas.Models
{
    public class MedicModel:UserModel
    {
        public string numColegiado { get; set; } = string.Empty;

        public List<AppoModel> citas { get; set; }
        public List<PacientModel> pacientes { get; set; }
    }
}
