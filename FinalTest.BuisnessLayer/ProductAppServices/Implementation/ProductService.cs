using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
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
    public class ProductService
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
            if(products.Data?.Any() == true)
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
    }
}
