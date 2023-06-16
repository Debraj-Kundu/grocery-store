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
    public class TopOrderService : ITopOrderService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public TopOrderService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<TopOrderDomain>>> GetTopProducts(int number, int month, int year)
        {
            var result = await UnitOfWork.OrderRepository.GetTopOrders(number, month, year);
            var topOrders = Mapper.Map<IEnumerable<TopOrderDomain>>(result.Data);

            foreach (var order in topOrders)
            {
                var product = await UnitOfWork.ProductRepository.GetByIdAsync(order.ProductId);
                order.Product = Mapper.Map<ProductDomain>(product.Data);
            }

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<TopOrderDomain>>(topOrders, true, message);
        }
    }
}
