using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Models
{
    public class FileModel
    {
        public IFormFile FileData { get; set; }
        public int RequestId { get; set; }
        public string Comments { get; set; }
    }
}
