using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.User
{
    public  class UserResponseDTO
    {
    }
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }
        public bool IsAuthorize { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int userId { get; set; }
    }
    public class UserDetailResponseDTO
    {
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public int? Status { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? EmailId { get; set; }
        public string? UserImagePath { get; set; }
    }
}
