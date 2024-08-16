using AppMicroServiceProduct.Application.Common.Interfaces;
using AppMicroServiceProduct.Infrastructure.CommandPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppMicroServiceProduct.Infrastructure.DesignPatterns;

public abstract class BaseEntityFrameworkUnitOfWork<TDbContext>
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;

    public BaseEntityFrameworkUnitOfWork(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void BeginTransaction()
    {
        _dbContext.Database.BeginTransaction();
    }

    public int Commit()
    {
        var result = _dbContext.SaveChanges();
        return result;
    }

    public async Task<int> CommitAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result;
    }

    public void CommitTransaction()
    {
        _dbContext.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _dbContext.Database.RollbackTransaction();
    }
}

public class UnitOfWork : BaseEntityFrameworkUnitOfWork<ApplicationDbContext>, IUnitOfWork
{
    // private readonly IEventServiceStore _eventServiceStore;

    public UnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task CommitAndPublishDomainEventsAsync(CancellationToken cancellationToken = default)
    {
        // var entityForSave = GetEntityForSave();
        await _dbContext.SaveChangesAsync(cancellationToken);
        // await PublishEvents(entityForSave);
    }

    // private async Task PublishEvents(List<EntityEntry> entityForSave)
    // {
    //     foreach (var item in entityForSave)
    //     {
    //         var aggregateRoot = item.Entity as AggregateRoot<long>;
    //         if (aggregateRoot is not null && aggregateRoot.GetEvents().Any())
    //         {
    //             await _eventServiceStore.Save($"{item.Entity.GetType().Name}-{aggregateRoot.Id}",
    //                 aggregateRoot.Id,
    //             aggregateRoot.GetEvents());
    //         }
    //
    //     }
    // }

    private List<EntityEntry> GetEntityForSave()
    {
        return _dbContext.ChangeTracker
            .Entries()
            .Where(x => x.State == EntityState.Modified
                        || x.State == EntityState.Added
                        || x.State == EntityState.Deleted
                        || x.State == EntityState.Deleted
                        || x.State == EntityState.Unchanged)
            .ToList();
    }
}