using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IRequestService
    {
        Task<List<Request>> GetRequests();
        Task<Request> GetRequestById(int id);
        Task<Request> AddRequest(Request request);
        Task<Request> UpdateRequest(int id, Request request);
        Task<int> DeleteRequest(int id);

    }
}
