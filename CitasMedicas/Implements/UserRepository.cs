using CitasMedicas.BBDD;
using CitasMedicas.Models;
using CitasMedicas.Repository;
using CitasMedicas.Services;

namespace CitasMedicas.Implements
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(CitasMedicasDB context) :base(context)
        {

        }
    }
}
