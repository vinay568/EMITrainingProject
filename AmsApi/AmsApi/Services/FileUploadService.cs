using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using AmsApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AmsApi.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadRepository _fileUploadRepository;

        public FileUploadService(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public Task UploadFile(FileModel file)
        {
            return _fileUploadRepository.UploadFile(file);  
        }
    }
}
