using EF.Service.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace EF.Service;

public abstract class BaseRepository<TContext> : IUnitOfWork where TContext : DbContext
{
    protected BaseRepository(TContext dbContext)
    {
        DbContext = dbContext;
    }

    protected TContext DbContext { get; }

    public async Task<int> SaveChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }
    async Task IUnitOfWork.BeginTransaction()
    {
        await DbContext.Database.BeginTransactionAsync();
    }

    async Task IUnitOfWork.CommitTransaction()
    {
        await DbContext.Database.CommitTransactionAsync();
    }

    async Task IUnitOfWork.RollbackTransaction()
    {
        await DbContext.Database.RollbackTransactionAsync();
    }
}