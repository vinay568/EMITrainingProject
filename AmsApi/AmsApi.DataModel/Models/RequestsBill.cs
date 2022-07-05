using System;
using System.Collections.Generic;

#nullable disable

namespace AmsApi.DataModel.Models
{
    public partial class RequestsBill
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public string FilePath { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Request Request { get; set; }
    }
}
