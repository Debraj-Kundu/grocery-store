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
    public class CustomerService : ICustomerService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public CustomerService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CustomerDomain>>> GetAllCustomers()
        {
            IEnumerable<CustomerDomain> result = new List<CustomerDomain>();
            var customers = await UnitOfWork.CustomerRepository.GetAllAsync();
            if (customers.Data?.Any() == true)
            {
                result = Mapper.Map<IEnumerable<CustomerDomain>>(customers.Data);
            }
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CustomerDomain>>(result, true, message);
        }

        public async Task<OperationResult<CustomerDomain>> CreateCustomer(CustomerDomain item)
        {
            Customer customer = Mapper.Map<CustomerDomain, Customer>(item);
            customer.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.CustomerRepository.AddAsync(customer);

            item.Id = customer.Id;

            OperationResult result;

            result = await UnitOfWork.Commit();

            return new OperationResult<CustomerDomain>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

        public async Task<OperationResult<CustomerDomain>> GetCustomerWithDetails(string email, string password)
        {
            var product = await UnitOfWork.CustomerRepository.CheckForUser(email, password);
            var result = Mapper.Map<CustomerDomain>(product.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<CustomerDomain>(result, true, message);
        }
    }
}
