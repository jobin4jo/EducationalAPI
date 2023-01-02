using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult> AddCategory([FromBody] CategoryRequestDTO categoryRequset)
        {
            try
            {
                var data = await this._categoryRepository.AddCategory(categoryRequset);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { CategoryId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpGet("GetAllCategory")]

        public async Task<ActionResult> GetAllCategory()
        {
            try
            {
                var data = await this._categoryRepository.GetAllCategory();

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetByCategoryId(int Id )
        {
            try
            {
                var data = await this._categoryRepository.GetCategoryById(Id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpDelete("DeleteCategoryById")]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            try
            {
                var data = await this._categoryRepository.DeleteCategoryById(Id);

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
