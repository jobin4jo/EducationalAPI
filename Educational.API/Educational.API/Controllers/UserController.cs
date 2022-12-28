using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Registration([FromBody] UserRequestDTO register)
        {
            try
            {
                var data = await this.userRepository.UserRegisteration(register);
                if (data == 0)
                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "USER_EXISTS", Data = new { } });

                }
                else
                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { userId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
