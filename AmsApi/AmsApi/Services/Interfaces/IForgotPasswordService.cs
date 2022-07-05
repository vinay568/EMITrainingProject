using AmsApi.ServiceModel.DTOs.Request;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IForgotPasswordService
    {
        Task<bool> CheckEmployee(string Email);
        Task<string> ResetPassword(ForgotPasswordDto dto);
    }
}
