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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeDetailsDto>>> GetAllEmployees()
        {
            var employee = await _employeeService.GetEmployees();
            var response = _mapper.Map<IEnumerable<EmployeeDetailsDto>>(employee);
            return  Ok(response);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailsDto>> GetEmployeeById(int id)
        {
            var employeeDetails = await _employeeService.GetEmployee(id);
            var response = _mapper.Map<EmployeeDetailsDto>(employeeDetails);
            return Ok(response);
        }

        [HttpPost("AddEmployee")]
  
        public async Task<ActionResult<EmployeeDetailsDto>> AddEmployee([FromBody] Employee employee)
        {
            var employeeDetails = await _employeeService.AddEmployeee(employee);
            var response = _mapper.Map<EmployeeDetailsDto>(employeeDetails);
            return Ok(response);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployeee(id);
        }

    }
}
