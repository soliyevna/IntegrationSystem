using IntegrationSystem.DataAccess.DbContexts;
using IntegrationSystem.DataAccess.Interfaces;
using IntegrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationSystem.DataAccess.Repositories;

/// <summary>
/// Represents a base repository class for CRUD operations on entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
{
    protected readonly DataContext _dataContext;

    protected DbSet<TEntity> Collection { get; init; }

    private bool _disposed;

    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        Collection = dataContext.Set<TEntity>();
    }

    /// <inheritdoc/>
    public int Create(TEntity entity)
    {
        Collection.Add(entity);
        return entity.Id;
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var entity = Collection.Find(id);
        if (entity is not null)
        {
            Collection.Remove(entity);
        }
    }

    /// <inheritdoc/>
    public async Task<TEntity?> GetById(int id)
    {
        var entity = await Collection.FindAsync(id);
        return entity;
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        Collection.Update(entity);
    }

    /// <inheritdoc/>
    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// Disposes of the DataContext when the repository is no longer needed.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dataContext.Dispose();
            }

            _disposed = true;
        }
    }

    /// <summary>
    /// Disposes of the resources used by the repository, including the DataContext.
    /// </summary>
    /// <remarks>
    /// This method is called to clean up both managed and unmanaged resources. It calls <see cref="Dispose(bool)"/>
    /// with the disposing parameter set to true and suppresses finalization to avoid unnecessary GC overhead.
    /// </remarks>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
