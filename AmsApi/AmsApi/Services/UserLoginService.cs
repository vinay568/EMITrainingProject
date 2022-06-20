using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.Services.Interfaces;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public async Task<Employee> AuthenticateUser(UserLoginDto dto)
        {
            return await _userLoginRepository.AuthenticateUser(dto);
        }
    }
}
