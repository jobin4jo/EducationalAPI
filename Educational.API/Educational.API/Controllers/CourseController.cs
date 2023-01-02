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
    }
}
