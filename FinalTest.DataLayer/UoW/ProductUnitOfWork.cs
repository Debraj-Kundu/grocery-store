using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Repository.Implementation;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.SharedLayer.Core.ExceptionManagement;
using FinalTest.SharedLayer.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.UoW
{
    public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
    {


        public ProductUnitOfWork(ProductDomainDbContext context, IOrderRepository orderRepository, IProductRepository productRepository, ICustomerCartRepository customerCartRepository, ICategoryRepository categoryRepository, ICustomerRepository customerRepository, IReviewRepository reviewRepository, IExceptionManager exceptionManager) : base(context, exceptionManager)
        {
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            CustomerCartRepository = customerCartRepository;
            CategoryRepository = categoryRepository;
            CustomerRepository = customerRepository;
            ReviewRepository = reviewRepository;
        }

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }

        public ICustomerCartRepository CustomerCartRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IReviewRepository ReviewRepository { get; }
    }
}
