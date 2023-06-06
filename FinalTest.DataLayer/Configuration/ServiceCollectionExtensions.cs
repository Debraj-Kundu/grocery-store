using FinalTest.DataLayer.DataContext;
using FinalTest.DataLayer.Repository.Implementation;
using FinalTest.DataLayer.Repository.Interface;
using FinalTest.DataLayer.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ProductDomainDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerCartRepository, CustomerCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
            
            return services;
        }
    }
}
