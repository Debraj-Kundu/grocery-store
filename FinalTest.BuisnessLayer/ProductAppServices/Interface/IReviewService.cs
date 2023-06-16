using FinalTest.BuisnessLayer.Domain;
using FinalTest.SharedLayer.Core.ValueObjects;
using System.Threading.Tasks;

namespace FinalTest.BuisnessLayer.ProductAppServices.Interface
{
    public interface IReviewService
    {
        Task<OperationResult<ReviewDomain>> SaveReview(ReviewDomain item);
    }
}