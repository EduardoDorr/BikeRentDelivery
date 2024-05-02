using Microsoft.EntityFrameworkCore.Storage;

using BikeRentDelivery.Common.Persistence.UnitOfWork;

using BikeRentDelivery.Infrastructure.Persistence.Contexts;

namespace BikeRentDelivery.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    protected readonly BikeRentDeliveryDbContext _dbContext;
    protected IDbContextTransaction? _transaction;

    public UnitOfWork(BikeRentDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _dbContext.Dispose();
    }
}