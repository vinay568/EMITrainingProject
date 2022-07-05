using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.ServiceModel.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AmsDbContext _context;

        public EmployeeRepository(AmsDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployeee(Employee employee)
        {
            try
            {
                if(employee != null)
                {
                    await _context.Employees.AddAsync(employee);
                    await _context.SaveChangesAsync();

                    return employee;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteEmployeee(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if(employee != null)
                {
                   _context.Employees.Remove(employee);
                   await _context.SaveChangesAsync();

                    return employee.Id;
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }


        public async Task<Employee> UpdateEmployeee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
