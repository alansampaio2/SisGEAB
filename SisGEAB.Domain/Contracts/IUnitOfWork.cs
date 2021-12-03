namespace SisGEAB.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IEnfermeiroRepository Enfermeiros { get; }

        int SaveChanges();
    }
}
