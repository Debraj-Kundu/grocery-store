using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ProductDomainDbContext context) : base(context)
        {

        }
        public override Task AddAsync(Order entity)
        {
            return base.AddAsync(entity);
        }

        public override void DeleteAsync(Order entity)
        {
            base.DeleteAsync(entity);
        }

        public override async Task<OperationResult<IEnumerable<Order>>> GetAllAsync()
        {
            var result = await base.GetAllAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Order>>(result.Data, result.IsSuccess, message);
        }

        public override void UpdateAsync(Order entity)
        {
            base.UpdateAsync(entity);
        }
    }
}
