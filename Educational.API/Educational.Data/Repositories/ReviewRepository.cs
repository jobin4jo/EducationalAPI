using AutoMapper;
using Educational.DataContracts.DataTransferObjects.Review;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public readonly EducationalContext _context;
        private readonly IMapper _mapper;
        public ReviewRepository(EducationalContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;   
        }

        public async Task<int> CreateReview(ReviewRequestDTO reviewRequestDTO)
        {
            TbReview tbReview = new TbReview();
            tbReview.ReviewerName = reviewRequestDTO.ReviewerName;
            tbReview.ReviewerEmail = reviewRequestDTO.ReviewerEmail;
            tbReview.ReviewDescription=reviewRequestDTO.ReviewDescription;  
            tbReview.ReviewRating=reviewRequestDTO.ReviewRating;
            tbReview.CourseId = reviewRequestDTO.CourseId;
            tbReview.UserId = reviewRequestDTO.UserId;
            tbReview.ReviewCreatedOn = reviewRequestDTO.ReviewCreatedOn;
            tbReview.Status = 1;
            this._context.TbReviews.Add(tbReview);
            await this._context.SaveChangesAsync();
            return tbReview.ReviewId;
        }

        public async Task<List<ReviewResponseDTO>> GetAllReviews()
        {
            List<ReviewResponseDTO> reviewResponses = await (from review in this._context.TbReviews
                                                             where review.Status == 1
                                                             select (new ReviewResponseDTO
                                                             {
                                                                 ReviewId = review.ReviewId,
                                                                 ReviewerEmail = review.ReviewerEmail,
                                                                 Status = review.Status,
                                                                 ReviewCreatedOn = review.ReviewCreatedOn,
                                                                 ReviewDescription = review.ReviewDescription,
                                                                 ReviewerName= review.ReviewerName, 
                                                                 ReviewRating = review.ReviewRating,    
                                                                 UserId=review.UserId,
                                                                 CourseId=review.CourseId,  
                                                                 
                                                                 

                                                             })).ToListAsync();
            return reviewResponses;
        }

        public async  Task<ReviewResponseDTO> GetReviewById(int reviewId)
        {
         ReviewResponseDTO reviewResponseDTO = await ( from  review in this._context.TbReviews
                                                       where review.Status==1 && review.ReviewId==reviewId
                                                       select (new ReviewResponseDTO
                                                       {
                                                           ReviewId = review.ReviewId,
                                                           ReviewerEmail = review.ReviewerEmail,
                                                           Status = review.Status,
                                                           ReviewCreatedOn = review.ReviewCreatedOn,
                                                           ReviewDescription = review.ReviewDescription,
                                                           ReviewerName = review.ReviewerName,
                                                           ReviewRating = review.ReviewRating,
                                                           UserId = review.UserId,
                                                           CourseId = review.CourseId,

                                                       })).FirstAsync();
            return reviewResponseDTO;
        }

        public async Task<bool> ReviewDeletebyId(int reviewId)
        {
            var reviewData = await this._context.TbReviews.FindAsync(reviewId);
            reviewData.Status = 0;
            this._context.Entry(reviewData).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
            if (reviewData.ReviewId != null)
            {
                return true;
            }
            return true;
        }

        public async Task<ReviewResponseDTO> UpdateReview(ReviewRequestDTO reviewRequestDTO,int reviewId )
        {
            var reviewData = await this._context.TbReviews.FindAsync(reviewId);
            reviewData.Status = 1;
            reviewData.ReviewerName = reviewRequestDTO.ReviewerName;
            reviewData.ReviewerEmail = reviewRequestDTO.ReviewerEmail;
            reviewData.ReviewRating = reviewRequestDTO.ReviewRating;
            reviewData.CourseId = reviewRequestDTO.CourseId;
            reviewData.UserId = reviewRequestDTO.UserId;
            reviewData.ReviewCreatedOn = reviewRequestDTO.ReviewCreatedOn;
            this._context.Update(reviewData);
            await this._context.SaveChangesAsync();
            var reviewDto = _mapper.Map<ReviewResponseDTO>(reviewData);
            return reviewDto;
        }
    }
}
