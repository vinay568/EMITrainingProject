using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.ServiceModel.DTOs.Response;
using AmsApi.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusesController : ControllerBase
    {
        private readonly IRequestStatusService _requestStatusService;
        private readonly IMapper _mapper;

        public RequestStatusesController(IRequestStatusService requestStatusService, IMapper mapper)
        {
            _requestStatusService = requestStatusService;
            _mapper = mapper;
        }

        [HttpPut("SetApprovedStatus")]
        public async Task<ActionResult<RequestDataDto>> SetApprovedStatus(int id,[FromBody] RequestDataDto requestDetails)
        {
            var response = _mapper.Map<Request>(requestDetails);
            var requestNew = await _requestStatusService.SetApprovedStatus(id,response);
            var requestStatus = _mapper.Map<RequestDetailsDto>(requestNew);
            return Ok(requestStatus);
        }

        [HttpPut("SetRejectedStatus")]
        public async Task<ActionResult<RequestDataDto>> SetRejectedStatus(int id, [FromBody] RequestDataDto requestDetails)
        {
            var response = _mapper.Map<Request>(requestDetails);
            var requestNew = await _requestStatusService.SetRejectedStatus(id, response);
            var requestStatus = _mapper.Map<RequestDetailsDto>(requestNew);
            return Ok(requestStatus);
        }

        [HttpPut("SetForwardedStatus")]
        public async Task<ActionResult<RequestDataDto>> SetForwardedStatus(int id, [FromBody] RequestDataDto requestDetails)
        {
            var response = _mapper.Map<Request>(requestDetails);
            var requestNew = await _requestStatusService.SetForwardedStatus(id, response);
            var requestStatus = _mapper.Map<RequestDetailsDto>(requestNew);
            return Ok(requestStatus);
        }
    }
}
