using Educational.DataContracts.DataTransferObjects.Course;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly ICourseDetailRepository _courseDetail;
        public CourseController(ICourseDetailRepository courseDetail)
        {
            this._courseDetail = courseDetail;
        }

        [HttpPost("AddCourse")]
        public async Task<ActionResult> AddCourse([FromBody] CourseRequestDTO courseRequest)
        {
            try
            {
                var data = await this._courseDetail.AddCourseDetail(courseRequest);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { CourseId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpPost("GetAllCourse")]
        public async Task<ActionResult> GetAlCourse(CourseDefaultRequest courseDefault)
        {
            try
            {
                var data = await this._courseDetail.GetAllCourseList(courseDefault);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data= data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("Search")]
        public async Task<ActionResult> SearcCourse(string name)
        {
            try
            {
                var data = await this._courseDetail.SearchCourseDetails(name);  

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpDelete("DeleteByCourseId")]
        public async Task<ActionResult> DeleteByCourseId (int id)
        {
            try
            {
                var data = await this._courseDetail.DeleteCourse(id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpGet("GetCourseDetailByCourseId")]
        public async Task<ActionResult> GetCourseDetailByCourseId(int id)
        {
            try
            {
                var data = await this._courseDetail.GetCourseDetailById(id);    

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
