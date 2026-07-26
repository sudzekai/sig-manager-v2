namespace Infrastructure.UOW
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
    }
}