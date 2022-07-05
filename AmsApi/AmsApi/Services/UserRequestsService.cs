using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Response;
using AmsApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class UserRequestsService : IUserRequestsService
    {
        private readonly IUserRequestsRepository _userRequestsRepository;

        public UserRequestsService(IUserRequestsRepository userRequestsRepository)
        {
            _userRequestsRepository = userRequestsRepository;
        }

        public async Task<List<Request>> GetEmployeeRequests(int id)
        {
            return await _userRequestsRepository.GetEmployeeRequests(id);
        }

        public async Task<List<EmployeeRequestsDto>> GetManagerRequests(int id)
        {
            return await _userRequestsRepository.GetManagerRequests(id);
        }

        public async Task<List<Request>> GetRequestsByStatus(int status)
        {
            return await _userRequestsRepository.GetRequestsByStatus(status);
        }
    }
}
