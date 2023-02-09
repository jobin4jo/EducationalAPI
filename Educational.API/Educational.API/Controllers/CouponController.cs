using Educational.DataContracts.DataTransferObjects.Coupon;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository couponRepository;
        public CouponController(ICouponRepository couponRepository)
        {
            this.couponRepository = couponRepository;
        }
        [HttpPost("CreateCoupon")]
        public async Task<ActionResult> CreateCoupon([FromBody] CouponRequestDTO Requset)
        {
            try
            {
                var data = await this.couponRepository.CreateCoupon(Requset);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { CategoryId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("GetAllCoupon")]
        public async Task<ActionResult> GetAllCoupon()
        {
            try
            {
                var data = await this.couponRepository.GetAllCoupon();

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpDelete("DeleteById")]
        public async Task<ActionResult> DeleteById(int id )
        {
            try
            {
                var data = await this.couponRepository.CouponDeletebyId(id);

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
        public async Task<ActionResult> GetDetailById(int Id )
        {
            try
            {
                var data = await this.couponRepository.GetCouponById(Id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
