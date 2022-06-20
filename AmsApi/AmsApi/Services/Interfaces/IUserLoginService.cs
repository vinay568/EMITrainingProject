using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IUserLoginService
    {
        Task<Employee> AuthenticateUser(UserLoginDto userDto);
    }
}
