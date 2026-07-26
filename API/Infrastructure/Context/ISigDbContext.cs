using System.Data.Common;

namespace Infrastructure.Context
{
    public interface ISigDbContext
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task<DbCommand> CreateCommandAsync(string query, DbParameter[]? parameters = null);
        ValueTask DisposeAsync();
        Task RollBackAsync();
        Task TestConnectionAsync();
    }
}