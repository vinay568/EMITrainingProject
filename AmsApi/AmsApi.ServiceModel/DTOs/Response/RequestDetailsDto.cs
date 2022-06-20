using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.ServiceModel.DTOs.Response
{
    public class RequestDetailsDto
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public string Approver { get; set; }
        public int? EstimatedCost { get; set; }
        public int? AdvanceAmount { get; set; }
        public DateTime? PlanDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? ApproverId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string RejectedReason { get; set; }
        public int? ForwardedTo { get; set; }
    }
}
