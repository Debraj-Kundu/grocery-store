using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.DataLayer.Entity;
using FinalTest.DataLayer.UoW;
using FinalTest.SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Implementation
{
    public class ProductService : IProductService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public ProductService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<ProductDomain>>> GetAllProducts()
        {
            IEnumerable<ProductDomain> result = new List<ProductDomain>();
            var products = await UnitOfWork.ProductRepository.GetAllAsync();
            if (products.Data?.Any() == true)
            {
                result = Mapper.Map<IEnumerable<ProductDomain>>(products.Data);
            }
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDomain>>(result, true, message);
        }

        public async Task<OperationResult<ProductDomain>> CreateProduct(ProductDomain item)
        {
            Product product = Mapper.Map<ProductDomain, Product>(item);
            product.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.ProductRepository.AddAsync(product);

            item.Id = product.Id;

            OperationResult result;

            result = await UnitOfWork.Commit();

            return new OperationResult<ProductDomain>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        public async Task<OperationResult<ProductDomain>> GetProductById(int id)
        {
            var product = await UnitOfWork.ProductRepository.GetByIdAsync(id);
            ProductDomain result = Mapper.Map<ProductDomain>(product.Data);
            
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<ProductDomain>(result, true, message);
        }


        public async Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByParam(string name)
        {
            var product = await UnitOfWork.ProductRepository.GetByNameAsync(name);
            var result = Mapper.Map<IEnumerable<ProductDomain>>(product.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDomain>>(result, true, message);
        }

        public Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByDescription(string desc)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<IEnumerable<ProductDomain>>> GetProductByCategory(int categoryId)
        {
            var product = await UnitOfWork.ProductRepository.GetByCategoryAsync(categoryId);
            var result = Mapper.Map<IEnumerable<ProductDomain>>(product.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<ProductDomain>>(result, true, message);
        }

        public async Task UpdateProduct(int productId, ProductDomain product)
        {
            var productEntity = Mapper.Map<Product>(product);
            productEntity.ModifiedOnDate = DateTimeOffset.Now;
         
            await UnitOfWork.ProductRepository.UpdateAsync(productEntity);

            await UnitOfWork.Commit();

        }

        public async Task<OperationResult<ProductDomain>> RemoveProduct(int productId)
        {
            var product = await UnitOfWork.ProductRepository.GetByIdAsync(productId);
            if(product.Data == null)
            {
                Message errMsg = new Message(string.Empty, "Not Found");
                return new OperationResult<ProductDomain>(null, false, errMsg);
            }
            UnitOfWork.ProductRepository.DeleteAsync(product.Data);
            Message message = new Message(string.Empty, "Deleted Successfully");
            await UnitOfWork.Commit();
            return new OperationResult<ProductDomain>(null, true, message);
        }
    }
}
