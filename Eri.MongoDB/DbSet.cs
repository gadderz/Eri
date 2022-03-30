using Eri.MongoDB.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Eri.MongoDB;

public class DbSet<TEntity, TId> : IDbSet<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : IComparable<TId>, IEquatable<TId>
{
    private readonly IMongoCollection<TEntity> _collection;
    private readonly ContextBase _context;

    public DbSet(ContextBase contextBase, string collectionName)
    {
        _context = contextBase;
        _collection = GetCollectionByName(collectionName);
    }

    #region Private methods
    private IMongoCollection<TEntity> GetCollectionByName(string collectionName)
    {
        if (string.IsNullOrEmpty(collectionName))
            return _context._database.GetCollection<TEntity>(nameof(TEntity));

        return _context._database.GetCollection<TEntity>(collectionName);
    }

    private async Task<BulkWriteResult<TEntity>> BulkWriteAsync(IEnumerable<WriteModel<TEntity>> models)
    {
        return await _collection.BulkWriteAsync(models);
    }
    #endregion

    #region Implemented functions
    public virtual IQueryable<TEntity> AsQueryable()
    {
        return _collection.AsQueryable();
    }

    public virtual async ValueTask<long> DeleteAsync(TId id)
    {
        var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
        var result = await _collection.DeleteOneAsync(filter);

        return result.DeletedCount;
    }

    public virtual async ValueTask<long> DeleteAsync(IEnumerable<TId> ids)
    {
        List<WriteModel<TEntity>> models = new();

        foreach (var id in ids)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);

            models.Add(new DeleteOneModel<TEntity>(filter));
        }

        return (await BulkWriteAsync(models)).DeletedCount;
    }

    public virtual async ValueTask<long> DeleteWhereAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        var result = await _collection.DeleteManyAsync(filterExpression);

        return result.DeletedCount;
    }

    public virtual async Task<IEnumerable<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        var result =  await _collection.FindAsync(filterExpression);
        return result.ToEnumerable();
    }

    public virtual async Task<TEntity> FindByIdAsync(TId id)
    {
        return await FirstOrDefaultAsync(doc => doc.Id.Equals(id));
    }

    public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).FirstOrDefaultAsync();
    }

    public virtual async ValueTask<long> InsertAsync(TEntity document)
    {
        List<WriteModel<TEntity>> models = new() { new InsertOneModel<TEntity>(document) };

        return (await BulkWriteAsync(models)).InsertedCount;
    }

    public virtual async ValueTask<long> InsertAsync(IEnumerable<TEntity> documents)
    {
        List<WriteModel<TEntity>> models = new();

        foreach (var doc in documents)
        {
            models.Add(new InsertOneModel<TEntity>(doc));
        }

        return (await BulkWriteAsync(models)).InsertedCount;
    }

    public virtual async ValueTask<long> ReplaceAsync(TEntity document)
    {
        var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, document.Id);

        var result = await _collection.ReplaceOneAsync(filter, document);

        return result.ModifiedCount;
    }

    public virtual async ValueTask<long> ReplaceAsync(IEnumerable<TEntity> documents)
    {
        List<WriteModel<TEntity>> models = new();

        foreach (var document in documents)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, document.Id);

            models.Add(new ReplaceOneModel<TEntity>(filter, document));
        }

        return (await BulkWriteAsync(models)).ModifiedCount;
    }
    #endregion

}

public class DbSet<TEntity> : DbSet<TEntity, string>
    where TEntity : IEntity
{
    public DbSet(ContextBase contextBase, string collectionName) : base(contextBase, collectionName)
    {
    }
}

