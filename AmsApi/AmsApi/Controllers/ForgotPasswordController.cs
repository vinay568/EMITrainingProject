using AmsApi.ServiceModel.DTOs.Request;
using AmsApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IForgotPasswordService _forgotPasswordService;

        public ForgotPasswordController(IForgotPasswordService forgotPasswordService)
        {
            _forgotPasswordService = forgotPasswordService;
        }

        [HttpGet("CheckEmployeeExist")]   
        public async Task<IActionResult> CheckEmployeeExist(string Email)
        {
            return Ok(_forgotPasswordService.CheckEmployee(Email));
        }

        [HttpPut("ResetEmployeePassword")]
        public async Task<ActionResult> ResetEmployeePassword([FromBody] ForgotPasswordDto dto)
        {
            return Ok(_forgotPasswordService.ResetPassword(dto));
        }
    }
}
