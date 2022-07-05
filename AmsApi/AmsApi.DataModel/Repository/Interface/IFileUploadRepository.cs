using AmsApi.DataModel.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository.Interface
{
    public interface IFileUploadRepository
    {
        public Task UploadFile(FileModel fileModel);
    }
}
