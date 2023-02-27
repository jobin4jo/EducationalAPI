using Educational.DataContracts.DataTransferObjects.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public  interface IStateRepository
    {
        Task<List<StateResponseDTO>> GetAllStates();
        Task<List<StateResponseDTO>> GetAllStatesByCountryId(int countryId);
        Task <StateResponseDTO> UpdateState(StateRequestDTO stateRequest , int stateId);
        Task<int>StateDeleteById(int id);
        Task<StateResponseDTO> AddState(StateRequestDTO stateRequest);
    }
}
