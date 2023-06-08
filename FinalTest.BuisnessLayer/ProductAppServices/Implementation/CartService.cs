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
    public class CartService : ICartService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public CartService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CustomerCartDomain>>> GetCartByCustomer(int customerId)
        {
            var cart = await UnitOfWork.CustomerCartRepository.GetByCustomerAsync(customerId);
            var result = Mapper.Map<IEnumerable<CustomerCartDomain>>(cart.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CustomerCartDomain>>(result, true, message);
        }
        public async Task<OperationResult<CustomerCartDomain>> AddCartProduct(CustomerCartDomain product)
        {
            var cartProduct = Mapper.Map<CustomerCart>(product);
            cartProduct.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.CustomerCartRepository.AddAsync(cartProduct);

            product.Id = cartProduct.Id;

            OperationResult result;

            result = await UnitOfWork.Commit();

            return new OperationResult<CustomerCartDomain>(product, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        public async Task<OperationResult<CustomerCartDomain>> GetCartItemById(int id)
        {
            var item = await UnitOfWork.CustomerCartRepository.GetByIdAsync(id);
            CustomerCartDomain result = Mapper.Map<CustomerCartDomain>(item.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<CustomerCartDomain>(result, true, message);
        }
    }
}
