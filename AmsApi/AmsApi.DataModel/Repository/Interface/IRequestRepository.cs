using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetRequests();
        Task<Request> GetRequestById(int id);
        Task<Request> AddRequest(Request request);
        Task<Request> UpdateRequest(int id,Request request); 
        Task<int> DeleteRequest(int id);
    }
}
