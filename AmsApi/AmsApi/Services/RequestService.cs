using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Request> AddRequest(Request request)
        {
            return await _requestRepository.AddRequest(request);
        }

        public async Task<int> DeleteRequest(int id)
        {
            return await _requestRepository.DeleteRequest(id);
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _requestRepository.GetRequestById(id);
        }

        public async Task<List<Request>> GetRequests()
        {
            return await _requestRepository.GetRequests();
        }


        public async Task<Request> UpdateRequest(int id, Request request)
        {
            return await _requestRepository.UpdateRequest(id, request);
        }
    }
}
