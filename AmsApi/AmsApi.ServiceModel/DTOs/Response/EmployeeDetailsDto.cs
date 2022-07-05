using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.ServiceModel.DTOs.Response
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
