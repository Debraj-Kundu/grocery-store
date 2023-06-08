﻿using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface ICustomerService
    {
        Task<OperationResult<CustomerDomain>> CreateCustomer(CustomerDomain item);
        Task<OperationResult<IEnumerable<CustomerDomain>>> GetAllCustomers();
    }
}