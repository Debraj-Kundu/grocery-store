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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public ProductDomainDbContext Context { get; }

        public OrderRepository(ProductDomainDbContext context) : base(context)
        {
            Context = context;
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

        public override async Task UpdateAsync(Order entity)
        {
            await base.UpdateAsync(entity);
        }

        public async Task<OperationResult<IEnumerable<Order>>> GetAllByCustomerIdAsync(int customerId)
        {
            var result = await Context.Orders.Where(e => e.CustomerId.Equals(customerId)).ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Order>>(result, true, message);
        }
        public async Task<OperationResult<IEnumerable<TopOrder>>> GetTopOrders(int number, int month, int year)
        {
            /*
              select TOP 5 ProductId, Sum(Quantity) as totalCount from Orders
              where MONTH(OrderDate) = @month AND YEAR(OrderDate) = @year
              group by ProductId
              order by totalCount desc
             */
            var orderList = await Context.Orders.ToListAsync();
            var result = orderList.Where(o => o.OrderDate.Month == month && o.OrderDate.Year == year)
                         .GroupBy(o => o.ProductId)
                         .Select(g => new TopOrder { ProductId = g.Key, Quantity = g.Sum(o => o.Quantity) })
                         .OrderByDescending(x => x.Quantity)
                         .Take(number);
            //var resultList = new List<Order>();

            //foreach(var item in result)
            //{
            //    resultList = orderList.Where(o => o.ProductId.Equals(item.ProductId)).ToList();
            //}
            //(from o in res
            //          where o.OrderDate.Month == @month && o.OrderDate.Year == @year
            //          group o by o.ProductId into g
            //          orderby g.Sum(x => x.Quantity) descending
            //          select new { ProductId = g.Key, totalCount = g.Sum(x => x.Quantity) }).Take(5);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<TopOrder>>(result, true, message);
        }
    }
}
