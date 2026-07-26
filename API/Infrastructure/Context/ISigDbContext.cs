using SqlKata;
using System.Data.Common;

namespace Infrastructure.Context
{
    public interface ISigDbContext
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task<DbCommand> CreateCommandAsync(Query query);
        ValueTask DisposeAsync();
        Task RollBackAsync();
        Task TestConnectionAsync();
    }
}