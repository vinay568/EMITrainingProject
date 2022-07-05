using AmsApi.ServiceModel.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IForgotPasswordRepository
    {
        Task<bool> CheckEmployee(string Email);
        Task<string> ResetPassword(ForgotPasswordDto dto);
    }
}
