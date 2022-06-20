using AmsApi.DataModel.Models;
using AmsApi.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmsApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenService(IConfiguration configuration)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(Employee employeeInfo)
        {
            var claim = new List<Claim>()
            { 
                new Claim(JwtRegisteredClaimNames.Sub,employeeInfo.FirstName),
                new Claim(JwtRegisteredClaimNames.Sub, employeeInfo.Id.ToString()),
                new Claim("userRole",employeeInfo.RoleId.ToString()),
            };
            var credentials = new SigningCredentials(_symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();   
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
