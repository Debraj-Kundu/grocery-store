using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.DataLayer.UoW;
using FinalTest.SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
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
    }
}
