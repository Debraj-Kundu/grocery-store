using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface IProductService
    {
        Task UpdateProduct(int productId, ProductDomain product);
        Task<OperationResult<ProductDomain>> GetProductById(int id);
        Task<OperationResult<IEnumerable<ProductDomain>>> GetAllProducts();
        Task<OperationResult<ProductDomain>> CreateProduct(ProductDomain item);
        Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByParam(string name);
        Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByDescription(string desc);
        Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByCategory(int categoryId);
    }
}