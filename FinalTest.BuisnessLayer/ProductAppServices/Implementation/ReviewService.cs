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
    public class ReviewService : IReviewService
    {
        public IProductUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public ReviewService(IProductUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<ReviewDomain>> SaveReview(ReviewDomain item)
        {
            var review = Mapper.Map<ReviewDomain, Review>(item);
            review.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.ReviewRepository.AddAsync(review);

            item.Id = review.Id;

            OperationResult result;

            result = await UnitOfWork.Commit();

            return new OperationResult<ReviewDomain>(item, result.IsSuccess, result.MainMessage, result.AssociatedMessages.ToList<Message>());
        }

    }
}
