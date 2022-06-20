using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.ServiceModel.DTOs.Response;
using AmsApi.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestsController(IRequestService requestService, IMapper mapper )
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet("GetAllRequests")]
        public async Task<ActionResult<IEnumerable<RequestDetailsDto>>> GetAllRequests()
        {
            var requestDetails = await _requestService.GetRequests();
            var requests = _mapper.Map<IEnumerable<RequestDetailsDto>>(requestDetails);
            return Ok(requests);
        }

        [HttpGet("GetRequestById")]
        public async Task<ActionResult<RequestDetailsDto>> GetRequestById(int id)
        {
            var requestDetails = await _requestService.GetRequestById(id);
            var requests = _mapper.Map<RequestDetailsDto>(requestDetails);
            return Ok(requests);
        }
        [HttpPost("AddNewRequest")]
        public async Task<ActionResult<RequestDataDto>> AddNewRequest([FromBody] RequestDataDto request)
        {
            var response = _mapper.Map<Request>(request);
            var requestNew = await _requestService.AddRequest(response);
            var requestDetails = _mapper.Map<RequestDetailsDto>(requestNew);
            
            return Ok(requestDetails);
        }

        [HttpPut("UpdateRequest")]
        public async Task<ActionResult<RequestDataDto>> UpdateRequest(int id,[FromBody] RequestDataDto request)
        {
            var response = _mapper.Map<Request>(request);
            var requestNew = await _requestService.UpdateRequest(id,response);
            var requestDetails = _mapper.Map<RequestDetailsDto>(requestNew);

            return Ok(requestDetails);
        }

        [HttpDelete("DeleteRequest")]
        public async Task<int> DeleteRequest(int id)
        {
            return await _requestService.DeleteRequest(id);
        }
    }
}
