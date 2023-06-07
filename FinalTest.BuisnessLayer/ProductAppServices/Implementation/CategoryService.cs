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
    public class CategoryService : ICategoryService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
        public CategoryService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<CategoryDomain>> GetCategoryByName(string name)
        {
            var category = await UnitOfWork.CategoryRepository.GetByNameAsync(name);
            CategoryDomain result = Mapper.Map<CategoryDomain>(category.Data);

            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<CategoryDomain>(result, true, message);
        }
    }
}
