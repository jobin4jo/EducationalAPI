using Educational.DataContracts.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Common.Authentification
{
    public static  class Jwt
    {
        public static string GenerateJsonWebToken(TbUser login, string Key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity (new Claim[]
                {
                    new Claim (ClaimTypes.Name,login.UserName.ToString()),
                    new Claim (ClaimTypes.Role ,login.Role)

                }),
                Expires = DateTime.UtcNow.AddDays (7),
                SigningCredentials=new (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
