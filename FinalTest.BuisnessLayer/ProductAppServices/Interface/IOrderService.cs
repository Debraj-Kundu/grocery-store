using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface IOrderService
    {
        Task<OperationResult<OrderDomain>> AddOrder(OrderDomain product);
        Task<OperationResult<IEnumerable<OrderDomain>>> GetAllOrderByCustomer(int customerId);
    }
}