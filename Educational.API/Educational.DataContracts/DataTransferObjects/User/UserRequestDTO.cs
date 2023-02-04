using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects
{
    public  class UserRequestDTO
    {
        public int userId { get; set; } 
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? Status { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? EmailId { get; set; }
    }


    public class LoginRequestDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    public class changePassword
    {
        public string? PrevPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
