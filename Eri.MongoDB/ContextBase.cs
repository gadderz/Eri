using Eri.MongoDB.Interfaces;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Eri.MongoDB;

public class ContextBase : IDisposable
{
    internal readonly IMongoClient _client;
    internal readonly IMongoDatabase _database;

    public ContextBase([NotNull] string connectionString,[NotNull] string databaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(databaseName);
    }

    private bool _disposedValue;

    public DbSet<TEntity, TId> GetDbSet<TEntity, TId>(string collectionName = null)
        where TEntity : IEntity<TId>
        where TId : IComparable<TId>, IEquatable<TId>
    {
        return new DbSet<TEntity, TId>(this, collectionName);
    }

    public DbSet<TEntity> GetDbSet<TEntity>(string collectionName = null)
        where TEntity : IEntity
    {
        return new DbSet<TEntity>(this, collectionName);
    }

    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
            //_client.Cluster.Dispose();
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposedValue = true;
    }

}
