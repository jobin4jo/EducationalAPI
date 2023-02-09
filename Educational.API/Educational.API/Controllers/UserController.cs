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


        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDTO  login)
        {
            try
            {
                var data = await this.userRepository.login(login);  
                
                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { userId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult> GetAllUser()
        {
            try
            {
                var data = await this.userRepository.GetAllUser();

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { userId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpDelete("UserDeleteById")]
        public async Task<ActionResult> UserDeleteById(int UserId)
        {
            try
            {
                var data = await this.userRepository.DeleteUser(UserId);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA_DELETE_SUCCESS", Data = new { userId = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpPost("ChangePassword/{id}")]
        public async Task<ActionResult> ChangePassword(changePassword change,int id)
        {
            try
            {
                var data = await this.userRepository.ChangePassword(change,id);
                return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { userId = data } });
            }
            catch(Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
        [HttpGet("UserDetailGetByUserId")]
        public async Task<ActionResult>UserDetailById(int UserId)
        {
            try
            {
                var data = await this.userRepository.GetUserDetail(UserId);
                return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { userId = data } });
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
