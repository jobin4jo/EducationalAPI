using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.DataTransferObjects.User;
using Educational.DataContracts.Models;
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
        Task<List<UserRequestDTO>> GetAllUser();
        Task<int>DeleteUser(int Userid);
        Task<bool> ChangePassword(changePassword changePassword, int UserId);
        Task<UserDetailResponseDTO> GetUserDetail(int Userid);
    }
}
