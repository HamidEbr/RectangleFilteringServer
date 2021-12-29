using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Infrastructure.Repository.Dapper.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly IDbConnection _connection;
        private bool _disposed;

        protected IDbTransaction transaction;

        protected BaseRepository(IDbConnection connection)
        {
            _connection = connection;
            CheckIfDbNotExists();
        }

        private void CheckIfDbNotExists()
        {
            if (!File.Exists("rectangleDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("rectangleDatabase.sqlite");
            }
            CheckIfTableNotExists();
        }

        protected abstract void CheckIfTableNotExists();

        protected IDbTransaction BeginTransaction()
        {
            if (transaction != null)
                return transaction;

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            transaction = _connection.BeginTransaction();
            return transaction;
        }

        protected void Commit()
        {
            transaction?.Commit();
            transaction?.Connection?.Close();

            transaction?.Dispose();
            transaction = null;
        }
        protected void RollBack()
        {
            transaction?.Rollback();
            transaction?.Connection?.Close();

            transaction?.Dispose();
            transaction = null;
        }


        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _connection?.Dispose();

            _disposed = true;
        }
    }
}
