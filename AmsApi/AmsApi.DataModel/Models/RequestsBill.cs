using System;
using System.Collections.Generic;

#nullable disable

namespace AmsApi.DataModel.Models
{
    public partial class RequestsBill
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public byte[] Document { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Request Request { get; set; }
    }
}
