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
    public class UserLoginsController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserLoginsController(IUserLoginService userLoginService, IMapper mapper, ITokenService tokenService)
        {
            _userLoginService = userLoginService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<EmployeeDetailsDto>> AuthenticateUser([FromBody]UserLoginDto user)
        {
            ActionResult result = Unauthorized();
            var employee = await _userLoginService.AuthenticateUser(user);
            if (employee != null)
            {
                var tokenString = _tokenService.CreateToken(employee);
                result = Ok(new
                {
                    token = tokenString,
                    employeeInfo = _mapper.Map<EmployeeDetailsDto>(employee)
                }); 
                
            }
               
            return result;
        }
    }
}
