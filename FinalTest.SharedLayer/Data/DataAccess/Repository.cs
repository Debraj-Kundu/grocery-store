using FinalTest.SharedLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.SharedLayer.Data.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainBase, IDomain
    {

        protected DbContext dbContext;
        protected readonly DbSet<TEntity> dbset;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual void UpdateAsync(TEntity entity)
        {
            
        }
    }
}
