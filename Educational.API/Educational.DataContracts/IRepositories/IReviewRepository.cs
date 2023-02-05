using Educational.DataContracts.DataTransferObjects.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public interface IReviewRepository
    {
       Task<int>CreateReview(ReviewRequestDTO reviewRequestDTO);   
        Task<bool>ReviewDeletebyId (int reviewId);
        Task<ReviewResponseDTO>UpdateReview(ReviewRequestDTO reviewRequestDTO,int reviewId);
        Task<List<ReviewResponseDTO>> GetAllReviews();  
        Task<ReviewResponseDTO> GetReviewById(int reviewId);    
    }
}
