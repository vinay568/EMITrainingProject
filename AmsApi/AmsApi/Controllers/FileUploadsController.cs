using AmsApi.DataModel.Models;
using AmsApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadsController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost("UploadFile")]
        public async Task UploadFile([FromForm] FileModel file)
        {
            await _fileUploadService.UploadFile(file);
        }
    }
}
