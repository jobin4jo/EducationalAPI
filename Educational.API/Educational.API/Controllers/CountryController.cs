using Educational.DataContracts.DataTransferObjects.Country;
using Educational.DataContracts.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Educational.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpPost("AddCountry")]
        public async Task<ActionResult>AddCountry(CountryRequestDTO countryRequests)
        {
            try
            {
                await _countryRepository.AddCountry(countryRequests);
                return new CreatedResult(string.Empty, new { Code = 200, Status = true, Message = "DATA_INSERT_SUCCESS", Data = new { } });
            }
            catch(Exception ex)
            {
                return new CreatedResult(string.Empty, new { Code = 401, Status = false, Message = ex, Data = new { } });
            }
        }
    }
}
