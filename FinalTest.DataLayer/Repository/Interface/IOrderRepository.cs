using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<OperationResult<IEnumerable<Order>>> GetAllByCustomerIdAsync(int customerId);
    }
}
