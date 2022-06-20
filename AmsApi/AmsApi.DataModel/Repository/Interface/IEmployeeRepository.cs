using AmsApi.DataModel.Models;
using AmsApi.ServiceModel.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<int> AddEmployeee(Employee employee);
        Task<int> UpdateEmployeee(Employee employee);
        Task<int> DeleteEmployeee(int id);
    }
}
