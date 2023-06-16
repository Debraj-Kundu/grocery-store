using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface ITopOrderService
    {
        Task<OperationResult<IEnumerable<TopOrderDomain>>> GetTopProducts(int number, int month, int year);
    }
}