// using System.Linq.Expressions;

// namespace AppMicroServiceProduct.Infrastructure.Services;

// public class CommandRepository<TEntity> : BaseCommandRepository<TEntity, ApplicationDbContext, long>,
//     ICommandRepository<TEntity>
//     where TEntity : AggregateRoot<long>
// {
//     public CommandRepository(ApplicationDbContext dbContext) : base(dbContext)
//     {
//     }

//     public void PartialUpdateTest<TCollection>(TEntity entity, TEntity myObjToUpdate,
//         Func<TEntity, IEnumerable<TCollection>> selector)
//         where TCollection : LongEntity
//     {
//         try
//         {
//             _dbContext.Entry(entity).CurrentValues.SetValues(myObjToUpdate);
//             UpdateChildCollection(entity, myObjToUpdate, selector);
//             _dbContext.SaveChanges();
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e);
//             throw;
//         }
//     }

//     private void UpdateChildCollection<TParent, TChild>(TParent? dbItem, TParent? newItem,
//         Func<TParent, IEnumerable<TChild>> selector)
//         where TChild : LongEntity
//     {
//         if (dbItem is  null && newItem is null)
//             return;

//         long IdSelector(TChild p) => p.Id;
//         var dbItems = selector(dbItem!).ToList();
//         var newItems = selector(newItem!).ToList();


//         var original = dbItems.ToDictionary((Func<TChild, long>)IdSelector);
//         var updated = newItems.ToDictionary((Func<TChild, long>)IdSelector);

//         var toRemove = original.Where(i => !updated.ContainsKey(i.Key)).ToArray();
//         var removed = toRemove.Select(i => _dbContext.Entry(i.Value).State = EntityState.Deleted).ToArray();

//         var toUpdate = original.Where(i => updated.ContainsKey(i.Key)).ToList();
//         toUpdate.ForEach(i => _dbContext.Entry(i.Value).CurrentValues.SetValues(updated[i.Key]));

//         var toAdd = updated.Where(i => !original.ContainsKey(i.Key)).ToList();
//         toAdd.ForEach(i => _dbContext.Set<TChild>().Add(i.Value));
//     public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>>? expression = null)
//     {
//         return expression is null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(expression);
//     }

//     public TEntity Update(TEntity entity)
//     {
//         var updateResult = _dbContext.Update(entity);
//         return updateResult.Entity;
//     }
// }