using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Response;
using AmsApi.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestsController : ControllerBase
    {
        private readonly IUserRequestsService _userRequestsService;
        private readonly IMapper _mapper;

        public UserRequestsController(IUserRequestsService userRequestsService, IMapper mapper)
        {
            _userRequestsService = userRequestsService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet("GetManagerRequests")]
        public async Task<ActionResult<IEnumerable<EmployeeRequestsDto>>> GetManagerRequests(int id)
        {
            var requests = await _userRequestsService.GetManagerRequests(id);
            var response = _mapper.Map<IEnumerable<EmployeeRequestsDto>>(requests);
            return Ok(response);
        }
        
        [Authorize]
        [HttpGet("GetEmployeeRequests")]
        public async Task<ActionResult<IEnumerable<Request>>> GetEmployeeRequests(int id)
        {
            var requests = await _userRequestsService.GetEmployeeRequests(id);
            var response = _mapper.Map<IEnumerable<RequestDetailsDto>>(requests);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetRequestsByStatus")]
        public async Task<ActionResult<IEnumerable<RequestDetailsDto>>> GetRequestsByStatus(int id)
        {
            var requests = await _userRequestsService.GetRequestsByStatus(id);
            var response = _mapper.Map<IEnumerable<RequestDetailsDto>>(requests);
            return Ok(response);
        }
    }

}
