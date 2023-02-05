using Educational.DataContracts.DataTransferObjects.Tutor;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository tutorRepository;
        public TutorController(ITutorRepository tutorRepository)
        {
            this.tutorRepository = tutorRepository;
        }
        [HttpPost("AddTutor")]
        public async Task<ActionResult> AddTutor([FromBody]  TutorRequestDTO  tutorRequest)
        {
            try
            {
                var data = await this.tutorRepository.CreateTutor(tutorRequest);    

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }


        [HttpGet("GetAllTutorList")]
        public async Task<ActionResult> GetAllTutor()
        {
            try
            {
                var data = await this.tutorRepository.GetTutorList();

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
        public async Task<ActionResult> TutorDetailById(int id )
        {
            try
            {
                var data = await this.tutorRepository.TutorGetById(id);

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
                var data = await this.tutorRepository.DeleteTutor(id);

                {
                    return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA DELETE SUCESS", Data = new { Data = data } });

                }
            }
            catch (Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }

        [HttpPut("UpdateTutor/{id}")]
        public async Task<ActionResult> UpdateTutor(TutorRequestDTO  tutorRequest,   int id)
        {
            try
            {
                var data = await this.tutorRepository.UpdateTutor(tutorRequest,id);

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
