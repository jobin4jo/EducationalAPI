using Educational.Common.Authentification;
using Educational.DataContracts.DataTransferObjects;
using Educational.DataContracts.DataTransferObjects.User;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public readonly IConfiguration _configuration;
        public UserRepository(EducationalContext context,IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

       

        public async Task<int> UserRegisteration(UserRequestDTO userRequest)
        {
            TbUser userData = new TbUser();
            TbProfile profileData= new TbProfile();
            userData.UserName=userRequest.UserName;
            userData.Password = userRequest.Password;
            userData.Role = userRequest.Role;
            userData.Status = 1;
            userData.CreatedOn= DateTime.Now;
            profileData.PhoneNumber = userRequest.PhoneNumber;
            profileData.Address = userRequest.Address;
            profileData.City = userRequest.City;
            profileData.EmailId = userRequest.EmailId;
          
           
            this._context.Add(userData);

            await _context.SaveChangesAsync();
            profileData.UserId = userData.UserId;
            if(profileData.UserId!=null && profileData.UserId != 0)
            {
                this._context.TbProfiles.Add(profileData);  
                await _context.SaveChangesAsync();
            }
           
           
            return userData.UserId;
                
        }


        public async  Task<LoginResponseDTO> login(LoginRequestDTO loginRequest)
        {
            LoginResponseDTO loginData = new LoginResponseDTO();
            TbUser userData = this._context.TbUsers.FirstOrDefault(x => x.UserName == loginRequest.UserName);
            if (userData == null)
            {
                loginData.IsAuthorize = false;
                loginData.AccessToken = "";
                loginData.Name = "";
                return loginData;
            }
            else
            {
                loginData.IsAuthorize = true;
                loginData.AccessToken = Jwt.GenerateJsonWebToken(userData, this._configuration["AppSettings:JwtKey"]);
                loginData.Name = this._context.TbUsers.Where(o => o.UserId == userData.UserId).Select(o => o.UserName).FirstOrDefault();
                loginData.Role = userData.Role;
                return loginData;
            }
        }

        public async Task<List<UserRequestDTO>> GetAllUser()
        {
            List<UserRequestDTO> userResponse = await (from cat in this._context.TbUsers
                                               join pro in this._context.TbProfiles on cat.UserId equals pro.UserId
                                               where cat.Status == 1
                                               select new UserRequestDTO
                                               {
                                                   UserName = cat.UserName, 
                                                   EmailId= pro.EmailId,
                                                   Address=pro.Address,
                                                   City=pro.City,
                                                   State=pro.State,
                                                   Role=cat.Role
                                               }
                                               ).ToListAsync();
                                              
             
            return userResponse;
        }
    }
}
