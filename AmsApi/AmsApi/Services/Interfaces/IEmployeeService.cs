using AmsApi.DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<int> AddEmployeee(Employee employee);
        Task<int> UpdateEmployeee(Employee employee);
        Task<int> DeleteEmployeee(int id);
    }
}
