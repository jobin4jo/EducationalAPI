using Educational.DataContracts.DataTransferObjects.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public  interface ICityRepository
    {
        Task<List<CityResponseDTO>> GetAllCity();
        Task<List<CityResponseDTO>> GetAllCityByStateId(int Id );
        Task UpdateState(CityResponseDTO cityResponseDTO, int StateId );
        Task<int> DeleteState(int Id);
        Task<CityResponseDTO> AddState(CityRequestDTO cityRequestDTO);
    }
}
