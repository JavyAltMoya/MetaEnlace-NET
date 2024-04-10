namespace CitasMedicas.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IPacientRepository Pacient { get; }
        IMedicRepository Medic { get; }
        IAppoRepository Appo { get; }
        IDiagRepository Diag { get; }

        int Save();
    }
}
