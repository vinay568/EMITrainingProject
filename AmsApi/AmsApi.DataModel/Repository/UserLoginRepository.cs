using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly AmsDbContext _context;

        public UserLoginRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AuthenticateUser(UserLoginDto dto)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Email == dto.Email && x.Password ==dto.Password);
        }
    }
}
