using FinalTest.DataLayer.Entity;
using FinalTest.SharedLayer.Core.ValueObjects;
using FinalTest.SharedLayer.Data.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.DataLayer.Repository.Interface
{
    public interface ICustomerCartRepository : IRepository<CustomerCart>
    {
        Task<OperationResult<IEnumerable<CustomerCart>>> GetByCustomerAsync(int customerId);

    }
}