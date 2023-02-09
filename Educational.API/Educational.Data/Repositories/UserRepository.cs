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
            TbUser userData = this._context.TbUsers.FirstOrDefault(x => x.UserName == loginRequest.UserName && x.Password==loginRequest.Password && x.Status==1);
            if (userData == null)
            {
                loginData.IsAuthorize = false;
                loginData.AccessToken = "";
                loginData.Name = "";
                loginData.userId = 0;
                return loginData;
            }
            else
            {
                loginData.IsAuthorize = true;
                loginData.AccessToken = Jwt.GenerateJsonWebToken(userData, this._configuration["AppSettings:JwtKey"]);
                loginData.Name = this._context.TbUsers.Where(o => o.UserId == userData.UserId).Select(o => o.UserName).FirstOrDefault();
                loginData.Role = userData.Role;
                loginData.userId = userData.UserId;
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
                                                   userId= cat.UserId,  
                                                   UserName = cat.UserName, 
                                                   Password=cat.Password,
                                                   EmailId= pro.EmailId,
                                                   Address=pro.Address,
                                                   City=pro.City,
                                                   State=pro.State,
                                                   Role=cat.Role
                                               }
                                               ).ToListAsync();
                                              
             
            return userResponse;
        }

        public async  Task<int> DeleteUser(int Userid)
        {
           

          var UserData = await _context.TbUsers.FindAsync(Userid);
            UserData.Status = 0;
            UserData.DeletedOn = DateTime.Now;
            _context.Entry(UserData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return UserData.UserId;
        }

        public async  Task<bool> ChangePassword(changePassword changePassword, int UserId)
        {
            changePassword change = new changePassword();
            var userData = this._context.TbUsers.FirstOrDefault(x => x.UserId==UserId&&x.Status==1);
            if (userData != null)
            {
                userData.Status = 1;
                userData.Password = changePassword.NewPassword;
               
                _context.Attach(userData);
                _context.Entry(userData).Property(x => x.Password).IsModified = true;
               
                await _context.SaveChangesAsync();
                return true;    
            }
            return true;
        }

        public async Task<UserDetailResponseDTO> GetUserDetail(int Userid)
        {
            UserDetailResponseDTO userDetailResponse = await ( from user in _context.TbUsers
                                                               join pro in _context.TbProfiles
                                                               on user.UserId equals pro.UserId
                                                               where pro.UserId == Userid
                                                               select new UserDetailResponseDTO
                                                               {
                                                                   UserName=user.UserName,
                                                                   PhoneNumber=pro.PhoneNumber,
                                                                   Address=pro.Address,
                                                                   EmailId=pro.EmailId, 
                                                                   City=pro.City,
                                                                   Role=user.Role,
                                                                   State=pro.State,
                                                                   Status=user.Status, 
                                                                   UserImagePath=pro.UserImagePath

                                                               }).FirstAsync();
            return userDetailResponse;
        }
    }
}
