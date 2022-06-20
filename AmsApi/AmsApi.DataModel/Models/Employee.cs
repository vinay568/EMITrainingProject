using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace AmsApi.DataModel.Models
{
    public partial class Employee
    {
        public Employee()
        {
            RequestApproverNavigations = new HashSet<Request>();
            RequestEmployees = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Request> RequestApproverNavigations { get; set; }
        public virtual ICollection<Request> RequestEmployees { get; set; }
    }
}
