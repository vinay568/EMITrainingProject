using AmsApi.DataModel.Models;
using AmsApi.DataModel.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Repository
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        private readonly AmsDbContext _context;
        private static IEnumerable<List<FileRecord>> _fileRecord;

        public FileUploadRepository(AmsDbContext context, IEnumerable<List<FileRecord>> fileRecord)
        {
            _fileRecord = fileRecord;
            _context = context;
        }

        public async Task UploadFile(FileModel formFile)
        {
            try
            {
                FileRecord file = await SaveFileAsync(formFile.FileData);
                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.RequestId = formFile.RequestId;
                    file.Comments = formFile.Comments;
                    SaveToDb(file);
                }
            }
            catch
            {
                throw;
            }
        }

        private void SaveToDb(FileRecord file)
        {
            if (file == null)
            {
                throw new ArgumentNullException($"nameof{file}");
            }
            RequestsBill requestBill = new RequestsBill();
            requestBill.FileName = file.FileName;
            requestBill.FileExtension = file.FileExtension;
            requestBill.FilePath = file.FilePath;
            requestBill.MimeType = file.FileType;
            requestBill.CreatedOn = DateTime.Today;
            requestBill.Comments = file.Comments;
            requestBill.RequestId = file.RequestId;

            _context.RequestsBills.AddAsync(requestBill);
            _context.SaveChangesAsync();
        }

        private async Task<FileRecord> SaveFileAsync(IFormFile formFile)
        {
            FileRecord file = new FileRecord();
            if (formFile != null)
            {
                if (Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(formFile.FileName);
                var path = Path.Combine(AppDirectory, fileName);
                file.Id = _fileRecord.Count() + 1;
                file.FilePath = path;
                file.FileName = fileName;
                file.FileExtension = Path.GetExtension(formFile.FileName);
                file.FileType = formFile.ContentType;
                FileStream fileStream = new FileStream(path, FileMode.Create);
                await fileStream.CopyToAsync(fileStream);
            }

            return file;
        }
    }
}
