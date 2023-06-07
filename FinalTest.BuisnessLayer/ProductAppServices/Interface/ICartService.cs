using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface ICartService
    {
        Task<OperationResult<IEnumerable<CustomerCartDomain>>> GetCartByCustomer(int customerId);
    }
}