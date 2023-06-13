using AutoMapper;
using FinalTest.BuisnessLayer.Domain;
using FinalTest.BuisnessLayer.ProductAppServices.Interface;
using FinalTest.DataLayer.UoW;
using FinalTest.SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<OperationResult<IEnumerable<CategoryDomain>>> GetAllCategories()
        {
            IEnumerable<CategoryDomain> result = new List<CategoryDomain>();
            var categories = await UnitOfWork.CategoryRepository.GetAllAsync();
            if (categories.Data?.Any() == true)
            {
                result = Mapper.Map<IEnumerable<CategoryDomain>>(categories.Data);
                
            }
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<CategoryDomain>>(result, true, message);
        }
    }
}
