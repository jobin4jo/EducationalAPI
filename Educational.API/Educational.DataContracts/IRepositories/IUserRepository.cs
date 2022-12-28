using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public interface IUserRepository
    {
        Task<int> UserRegisteration(UserRequestDTO userRequest);
        Task<LoginResponseDTO> login(LoginRequestDTO loginRequest);
    }
}
