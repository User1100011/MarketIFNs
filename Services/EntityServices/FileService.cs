using CSharpFunctionalExtensions;
using Market.Models.Entityes;
using Market.Interfaces.FileInterfaces;
using System.IO;

namespace Market.Services.EntityServices
{
    public class FileService : IFileCreateAsync
    {
        private const string fileStorage = @"C:\Timur_Directoryes\Files\Images";

        public virtual async Task<Result<FileEntity>> Create(IFormFile formFile)
        {
            if (formFile is null)
                return Result.Failure<FileEntity>("FormFile is null");

            try
            {
                var id = Guid.NewGuid();
                var name = formFile.FileName;

                var filePath = Path.Combine(fileStorage, id.ToString());

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                return Result.Success(new FileEntity { FileId = id, Name = name, Path = filePath });
            }
            catch (Exception ex)
            {
                return Result.Failure<FileEntity>(ex.Message);
            }
        }

    }
}