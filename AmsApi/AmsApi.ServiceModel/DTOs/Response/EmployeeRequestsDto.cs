using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.ServiceModel.DTOs.Response
{
    public class EmployeeRequestsDto
    {
        public RequestDetailsDto Requests { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
