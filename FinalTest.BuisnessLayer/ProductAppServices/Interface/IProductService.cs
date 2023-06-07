using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface IProductService
    {
        Task<OperationResult<ProductDomain>> CreateProduct(ProductDomain item);
        Task<OperationResult<IEnumerable<ProductDomain>>> GetAllProducts();
        Task<OperationResult<ProductDomain>> GetProductById(int id);
    }
}