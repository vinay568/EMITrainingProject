using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class UserRequestsRepository : IUserRequestsRepository
    {
        private readonly AmsDbContext _context;

        public UserRequestsRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetEmployeeRequests(int id)
        {
            List<Request> requests = new List<Request>();
            foreach (var request in _context.Requests)
            {
                if (request.EmployeeId == id)
                {
                    requests.Add(request);
                }
            }
            requests.Reverse();
            return requests;
        }

        public async Task<List<Request>> GetManagerRequests(int id)
        {

            List<Request> requests = new List<Request>();
            foreach (var request in _context.Requests)
            {
                if (request.ApproverId == id || request.ForwardedTo == id)
                {
                    requests.Add(request);
                }
            }
            requests.Reverse();
            return requests;
        }

        public async Task<List<Request>> GetRequestsByStatus(int statusId)
        {
            List<Request> requests = new List<Request>();
            foreach(var request in _context.Requests)
            {
                if(request.Status == statusId)
                {
                    requests.Add(request);
                }
            }
            requests.Reverse();
            return requests;

        }
    }
}
