using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly AmsDbContext _context;

        public RequestStatusRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<Request> SetApprovedStatus(int id, Request requestDetails)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return null;
            }
            else
            {
                request.Status = 2;
                request.UpdatedOn = System.DateTime.Today;
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return request;
            }
        }

        public async Task<Request> SetRejectedStatus(int id, Request requestDetails)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return null;
            }
            else
            {
                request.Status = 3;
                request.UpdatedOn = System.DateTime.Today;
                request.RejectedReason = requestDetails.RejectedReason;
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return request;
            }
        }

        public async Task<Request> SetForwardedStatus(int id, Request requestDetails)
        {

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return null;
            }
            else
            {
                request.Status = 4;
                request.UpdatedOn = System.DateTime.Today;
                request.ForwardedTo = requestDetails.ForwardedTo;
                _context.Requests.Update(request);
                await _context.SaveChangesAsync();
                return request;
            }
        }
    }
}
