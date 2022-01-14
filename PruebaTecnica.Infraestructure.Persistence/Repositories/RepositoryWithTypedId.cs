using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaTecnica.Core.Application.Contracts.Persistence.Base;
using PruebaTecnica.Core.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace PruebaTecnica.Infraestructure.Persistence.Repositories
{
    /// <summary>
    /// Repository and UnitOfWork Design Pattern implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        /// <summary>
        /// Database context
        /// </summary>
        protected DbContext _dbContext;

        /// <summary>
        /// T Data in database
        /// </summary>
        protected DbSet<T> DbSet;

        /// <summary>
        /// Builds the object with the specified context
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryWithTypedId(DbContext context)
        {
            _dbContext = context;
            DbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Add a List of entities to DB Context
        /// </summary>
        /// <param name="entities">Entity List</param>
        /// <returns>Added Entities</returns>
        public async Task<IList<T>> AddRangeAsync(IList<T> entities, CancellationToken token = default)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities, token);
            await _dbContext.SaveChangesAsync(token);

            return entities;
        }

        /// <summary>
        /// Add a Entity to BD Context
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity, CancellationToken token = default)
        {
            await _dbContext.Set<T>().AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);

            return entity;
        }

        /// <summary>
        /// Delete a entity from Db Context
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns></returns>
        public async Task DeleteAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Get a entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(TId id) =>
            await _dbContext.Set<T>().FindAsync(id);

        /// <summary>
        /// Make a query to Db
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> Query() =>
          DbSet;

        /// <summary>
        /// Confirm the Changes to DB
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync(CancellationToken token = default) =>
            await _dbContext.SaveChangesAsync(token);

        /// <summary>
        /// Update a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity, CancellationToken token = default)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Begins the Db transaction
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction BeginTransaction() =>
            _dbContext.Database.BeginTransaction();
    }
}
