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
    public class OrderService : IOrderService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public OrderService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<OrderDomain>>> GetAllOrderByCustomer(int customerId)
        {
            IEnumerable<OrderDomain> result = new List<OrderDomain>();
            var products = await UnitOfWork.OrderRepository.GetAllByCustomerIdAsync(customerId);
            if (products.Data?.Any() == true)
            {
                result = Mapper.Map<IEnumerable<OrderDomain>>(products.Data).ToList();
                foreach (var item in result)
                {
                    var prod = await UnitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                    item.Product = Mapper.Map<ProductDomain>(prod.Data);
                }
            }
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<OrderDomain>>(result, true, message);
        }

        public async Task<OperationResult<OrderDomain>> AddOrder(OrderDomain product)
        {
            var orderProduct = Mapper.Map<Order>(product);
            orderProduct.OrderDate = DateTime.Now;
            orderProduct.CreatedOnDate = DateTimeOffset.Now;


            OperationResult result;

            //result = await UnitOfWork.Commit();

            using (var transaction = UnitOfWork.BeginTransaction())
            {
                await UnitOfWork.OrderRepository.AddAsync(orderProduct);
                var productToUpdate = await UnitOfWork.ProductRepository.GetByIdAsync(product.ProductId);
                var cartItemToDelete = await UnitOfWork.CustomerCartRepository.GetByIdAsync(product.CartId);
                if (product.Quantity <= productToUpdate.Data.AvailableQuantity)
                {
                    productToUpdate.Data.AvailableQuantity -= product.Quantity;
                    await UnitOfWork.ProductRepository.UpdateAsync(productToUpdate.Data);
                    UnitOfWork.CustomerCartRepository.DeleteAsync(cartItemToDelete.Data);
                }

                result = await UnitOfWork.Commit();

                await transaction.CommitAsync();
            }

            product.Id = orderProduct.Id;

            return new OperationResult<OrderDomain>(product, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }
    }
}
