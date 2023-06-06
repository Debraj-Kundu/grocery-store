using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.SharedLayer.Data.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
