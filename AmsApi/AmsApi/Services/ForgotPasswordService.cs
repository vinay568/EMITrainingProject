using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.Services.Interfaces;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly IForgotPasswordRepository _forgotPasswordRepository;

        public ForgotPasswordService(IForgotPasswordRepository forgotPasswordRepository)
        {
            _forgotPasswordRepository = forgotPasswordRepository;
        }

        public async Task<bool> CheckEmployee(string Email)
        {
            return await _forgotPasswordRepository.CheckEmployee(Email);
        }

        public async Task<string> ResetPassword(ForgotPasswordDto dto)
        {
            return await _forgotPasswordRepository.ResetPassword(dto);
        }
    }
}
