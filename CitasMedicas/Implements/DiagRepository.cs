using CitasMedicas.BBDD;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implements
{
    public class DiagRepository : GenericRepository<DiagModel>, IDiagRepository
    {
        public DiagRepository(CitasMedicasDB context) : base(context)
        {

        }
    }
}
