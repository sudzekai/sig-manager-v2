using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Infrastructure.Context
{
    internal class SigDbContext : IAsyncDisposable, ISigDbContext
    {
        private readonly ILogger<ISigDbContext> _logger;
        private readonly string _connectionString;

        private readonly MySqlConnection _connection;
        private MySqlTransaction? _transaction;

        public SigDbContext(string connectionString, ILogger<ISigDbContext> logger)
        {
            _logger = logger;
            _connectionString = connectionString;

            _connection = new MySqlConnection(connectionString);
        }

        public async Task TestConnectionAsync()
        {
            await using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
        }

        public async Task<DbCommand> CreateCommandAsync(string query, DbParameter[]? parameters = null)
        {
            await EnsureConnectedAsync();

            MySqlCommand command = _transaction is null
                        ? new(query, _connection)
                        : new(query, _connection, _transaction);

            _logger.LogDebug("{query}", query);

            if (parameters is not null)
            {
                command.Parameters.AddRange(parameters);

                StringBuilder sb = new();
                foreach (var param in parameters)
                    sb.Append($"\n[{param.ParameterName}] = \"{param.Value}\"");

                _logger.LogDebug(sb.ToString().Trim());
            }

            return command;
        }

        public async Task BeginTransactionAsync()
        {
            await EnsureConnectedAsync();

            if (_transaction is not null)
                throw new InvalidOperationException("Transaction already started.");

            _transaction = await _connection.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task RollBackAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }

        private async Task EnsureConnectedAsync()
        {
            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }

            await _connection.DisposeAsync();
        }
    }
}
