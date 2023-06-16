using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Interface
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<OperationResult<IEnumerable<Review>>> GetByProductAsync(int productId);
    }
}
