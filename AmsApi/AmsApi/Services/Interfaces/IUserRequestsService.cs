using AmsApi.DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IUserRequestsService
    {
        Task<List<Request>> GetManagerRequests(int id);
        Task<List<Request>> GetEmployeeRequests(int id);
        Task<List<Request>> GetRequestsByStatus(int status);
    }
}
