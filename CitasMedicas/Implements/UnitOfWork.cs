using CitasMedicas.BBDD;
using CitasMedicas.Repository;

namespace CitasMedicas.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CitasMedicasDB _context;
        public UnitOfWork(CitasMedicasDB context) 
        {
            _context = context;
            User = new UserRepository(_context);
            Medic = new MedicRepository(_context);
            Pacient = new PacientRepository(_context);
            Appo = new AppoRepository(_context);
            Diag = new DiagRepository(_context);
        }

        public IUserRepository User { get; private set; }
        public IMedicRepository Medic { get; private set; }
        public IPacientRepository Pacient { get; private set; }
        public IAppoRepository Appo { get; private set; }
        public IDiagRepository Diag { get; private set;}

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
