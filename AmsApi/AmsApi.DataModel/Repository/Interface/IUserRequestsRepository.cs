using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IUserRequestsRepository
    {
        Task<List<Request>> GetManagerRequests(int id);
        Task<List<Request>> GetEmployeeRequests(int id);
        Task<List<Request>> GetRequestsByStatus(int status);
    }
}
