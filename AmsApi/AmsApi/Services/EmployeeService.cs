using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> AddEmployeee(Employee employee)
        {
            return await _employeeRepository.AddEmployeee(employee);
        }

        public async Task<int> DeleteEmployeee(int id)
        {
            return await _employeeRepository.DeleteEmployeee(id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        public async Task<int> UpdateEmployeee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployeee(employee);
        }
    }
}
