using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.UoW
{
    public interface IProductUnitOfWork : IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        ICustomerCartRepository CustomerCartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IReviewRepository ReviewRepository { get; }

    }
}
