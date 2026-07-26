using Infrastructure.Context;

namespace Infrastructure.UOW
{
    internal class UnitOfWork(ISigDbContext db) : IUnitOfWork
    {
        public async Task BeginTransactionAsync()
            => await db.BeginTransactionAsync();

        public async Task CommitAsync()
            => await db.CommitAsync();

        public async Task RollBackAsync()
            => await db.RollBackAsync();
    }
}
