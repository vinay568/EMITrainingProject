using AmsApi.DataModel.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AmsApi.Services.Interfaces
{
    public interface IFileUploadService
    {
        public Task UploadFile(FileModel file);
    }
}
