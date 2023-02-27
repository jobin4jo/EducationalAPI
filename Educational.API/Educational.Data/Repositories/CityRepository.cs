using Educational.DataContracts.DataTransferObjects.City;
using Educational.DataContracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        public Task<CityResponseDTO> AddState(CityRequestDTO cityRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteState(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CityResponseDTO>> GetAllCity()
        {
            throw new NotImplementedException();
        }

        public Task<List<CityResponseDTO>> GetAllCityByStateId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateState(CityResponseDTO cityResponseDTO, int StateId)
        {
            throw new NotImplementedException();
        }
    }
}
