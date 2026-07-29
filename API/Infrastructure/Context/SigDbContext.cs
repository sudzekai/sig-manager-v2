using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Compilers;
using System.Data;
using System.Data.Common;

namespace Infrastructure.Context
{
    internal class SigDbContext : IAsyncDisposable, ISigDbContext
    {
        private readonly ILogger<ISigDbContext> _logger;
        private readonly string _connectionString;

        private static MySqlCompiler _compiler = new();

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

        public async Task<DbCommand> CreateCommandAsync(Query query)
        {
            await EnsureConnectedAsync();

            var compiled = _compiler.Compile(query);
            _logger.LogDebug($"""
            Executing DB query

            Query:
            {compiled.Sql}

            Parameters:
            {string.Join(Environment.NewLine,
                        compiled.Bindings.Select((x, i) => $"@p{i} = {x ?? "NULL"}"))}
            """);

            MySqlCommand command = _transaction is null
                ? new(compiled.Sql, _connection)
                : new(compiled.Sql, _connection, _transaction);

            for (int i = 0; i < compiled.Bindings.Count; i++)
                command.Parameters.AddWithValue($"@p{i}", compiled.Bindings[i]);

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
