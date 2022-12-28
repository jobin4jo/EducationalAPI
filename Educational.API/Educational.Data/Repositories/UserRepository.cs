using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class UserRepository : IUserRepository
    {


        public readonly EducationalContext _context;

        public UserRepository(EducationalContext context)
        {
            this._context = context;
        }

        public async Task<int> UserRegisteration(UserRequestDTO userRequest)
        {
            TbUser userData = new TbUser();
            userData.UserName=userRequest.UserName;
            userData.Password = userRequest.Password;
            userData.Role = userRequest.Role;
            userData.Status = 1;
            userData.CreatedOn= DateTime.Now;
           
            this._context.Add(userData);
            await _context.SaveChangesAsync();
           
            return userData.UserId;
                
        }
    }
}
