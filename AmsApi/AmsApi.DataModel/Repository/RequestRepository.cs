using AmsApi.DataModel.Helpers;
using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AmsDbContext _context;

        public RequestRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<Request> AddRequest(Request request)
        {
            request.CreatedOn = System.DateTime.Today;
            await _context.Requests.AddAsync(request);
            
            var employeeEmail = _context.Employees.Where(employee => employee.Id == request.EmployeeId).Select(employee => employee.Email);
            var managerEmail = _context.Employees.Where(employee => employee.Id == request.ApproverId).Select(employee => employee.Email);
            EmailNotificationHelper.EmailNotification(employeeEmail.ToString(), managerEmail.ToString());
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<int> DeleteRequest(int id)
        {
            try
            {
                Request request = _context.Requests.SingleOrDefault(x => x.Id == id);
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch
            {
                throw;
            }
            return 0;
        }

        

        public async Task<Request> GetRequestById(int id)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public async Task<List<Request>> GetRequests()
        {
            return await _context.Requests.ToListAsync(); 
        }

        public async Task<Request> UpdateRequest(int id,Request request)
        {
            var existingRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRequest != null)
            {
                existingRequest.Purpose = request.Purpose;
                existingRequest.Approver = request.Approver;
                existingRequest.PlanDate = request.PlanDate;
                existingRequest.Description = request.Description;
                existingRequest.EstimatedCost = request.EstimatedCost;
                existingRequest.AdvanceAmount = request.AdvanceAmount;

                existingRequest.UpdatedOn = System.DateTime.Today;


                await _context.SaveChangesAsync();
                return existingRequest;
            }

            return null;
        }

        

    }
}
