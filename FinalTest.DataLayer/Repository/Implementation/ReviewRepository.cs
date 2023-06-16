using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ProductDomainDbContext Context { get; }

        public ReviewRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
        }
        public override async Task AddAsync(Review entity)
        {
            await base.AddAsync(entity);
        }

        public override void DeleteAsync(Review entity)
        {
            base.DeleteAsync(entity);
        }
        public override async Task UpdateAsync(Review entity)
        {
            await base.UpdateAsync(entity);
        }

        public override async Task<OperationResult<IEnumerable<Review>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Review>>(result.Data, result.IsSuccess, message);
        }

        public async Task<OperationResult<IEnumerable<Review>>> GetByProductAsync(int productId)
        {
            var result = await Context.Reviews.Where(e => e.ProductId.Equals(productId)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Review>>(result, true, message);
        }
    }
}
