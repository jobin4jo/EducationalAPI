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
    }
}
