using Educational.DataContracts.DataTransferObjects.State;
using Educational.DataContracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        public Task<StateResponseDTO> AddState(StateRequestDTO stateRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<StateResponseDTO>> GetAllStates()
        {
            throw new NotImplementedException();
        }

        public Task<List<StateResponseDTO>> GetAllStatesByCountryId(int countryId)
        {
            throw new NotImplementedException();
        }

        public Task<int> StateDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StateResponseDTO> UpdateState(StateRequestDTO stateRequest, int stateId)
        {
            throw new NotImplementedException();
        }
    }
}
