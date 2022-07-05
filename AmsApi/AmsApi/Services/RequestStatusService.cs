using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.Services.Interfaces;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class RequestStatusService : IRequestStatusService 
    {
        private readonly IRequestStatusRepository _requestStatusRepository;

        public RequestStatusService(IRequestStatusRepository requestStatusRepository)
        {
            _requestStatusRepository = requestStatusRepository;
        }

        public async Task<Request> SetApprovedStatus(int id, Request request)
        {
            return await _requestStatusRepository.SetApprovedStatus(id, request);
        }

        public async Task<Request> SetRejectedStatus(int id, Request request)
        {
            return await _requestStatusRepository.SetRejectedStatus(id, request);
        }

        public async Task<Request> SetForwardedStatus(int id, Request request)
        {
            return await _requestStatusRepository.SetForwardedStatus(id, request);
        }
        public async Task<Request> SetCompletedStatus(int id, Request request)
        {
            return await _requestStatusRepository.SetCompletedStatus(id, request);
        }
    }
}
