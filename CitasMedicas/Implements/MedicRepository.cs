using CitasMedicas.BBDD;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implements
{
    public class MedicRepository : GenericRepository<MedicModel>, IMedicRepository
    {
        public MedicRepository(CitasMedicasDB context) : base(context)
        {

        }
    }
}
