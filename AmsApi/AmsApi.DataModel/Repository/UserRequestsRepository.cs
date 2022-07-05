using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
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

        public async Task<List<EmployeeRequestsDto>> GetManagerRequests(int id)
        {
            var requests = from request in _context.Requests
                           join employee in _context.Employees on request.EmployeeId equals employee.Id
                           select new EmployeeRequestsDto()
                           { 
                              
                               RequestDetails = new RequestDetailsDto 
                               { 
                                   Id = request.Id,
                                   Purpose = request.Purpose,
                                   Description = request.Description,
                                   PlanDate = request.PlanDate,
                                   EstimatedCost = request.EstimatedCost,
                                   AdvanceAmount = request.AdvanceAmount,
                                   Status = request.Status,
                                   EmployeeId = request.EmployeeId,
                                   ForwardedTo = request.ForwardedTo,
                                   ApproverId = request.ApproverId,
                                   Approver = request.Approver,
                                  
                               },
                               FirstName = employee.FirstName,
                               PhoneNumber = employee.PhoneNumber,
                               Email = employee.Email,
                           };
            List<EmployeeRequestsDto> requestsDetails = new List<EmployeeRequestsDto>();
            foreach (var requestdetails in requests)
            {
                if (requestdetails.RequestDetails.ApproverId == id || requestdetails.RequestDetails.ForwardedTo == id)
                {
                    requestsDetails.Add(requestdetails);
                }
            }
            requestsDetails.Reverse();
            return requestsDetails;

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
