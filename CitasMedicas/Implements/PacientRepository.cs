using CitasMedicas.BBDD;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implements
{
    public class PacientRepository : GenericRepository<PacientModel>, IPacientRepository
    {
        public PacientRepository(CitasMedicasDB context) : base(context)
        {

        }
    }
}
