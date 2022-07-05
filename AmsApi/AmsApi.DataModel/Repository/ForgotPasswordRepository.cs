using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        private readonly AmsDbContext _context;

        public ForgotPasswordRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckEmployee(string Email)
        {
            if(Email != null)
            {
                var employee = _context.Employees.SingleOrDefault(x=> x.Email == Email);
                if(employee != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<string> ResetPassword(ForgotPasswordDto dto)
        {
            try
            {
                if(dto.Email != null)
                {
                    var employee = _context.Employees.SingleOrDefault(x => x.Email == dto.Email);
                    if(employee != null)
                    {
                        employee.Password = dto.Password;
                        _context.SaveChanges();
                    }
                    return "Password changed successfully";
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
