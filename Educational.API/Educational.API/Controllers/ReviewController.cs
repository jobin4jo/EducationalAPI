using Educational.DataContracts.DataTransferObjects.Review;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewRepository reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        [HttpPost("AddReview")]
        public async Task<ActionResult> AddReview([FromBody] ReviewRequestDTO Request)
        {
            try
            {
                var data = await this.reviewRepository.CreateReview(Request);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA INSERT SUCCESS", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("GetAllReview")]
        public async Task<ActionResult> GetAllReview()
        {
            try
            {
                var data = await this.reviewRepository.GetAllReviews();

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("DetailById")]
        public async Task<ActionResult> ReviewDetailById(int id)
        {
            try
            {
                var data = await this.reviewRepository.ReviewDeletebyId(id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpDelete("ById")]
        public async Task<ActionResult> DeletebyId(int id)
        {
            try
            {
                var data = await this.reviewRepository.ReviewDeletebyId(id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA DELETE SUCESS", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpPut("UpdateReview/{id}")]
        public async Task<ActionResult> UpdateTutor(ReviewRequestDTO Request, int id)
        {
            try
            {
                var data = await this.reviewRepository.UpdateReview(Request, id);   

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA UPDATE SUCESS", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
