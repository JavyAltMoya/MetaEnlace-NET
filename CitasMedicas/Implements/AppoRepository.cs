using CitasMedicas.BBDD;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implements
{
    public class AppoRepository : GenericRepository<AppoModel>, IAppoRepository
    {
        public AppoRepository(CitasMedicasDB context) : base(context)
        {

        }
    }
}
