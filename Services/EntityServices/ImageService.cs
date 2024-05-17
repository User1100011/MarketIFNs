using CSharpFunctionalExtensions;
using Market.Models.Entityes;
using Market.Interfaces.FileInterfaces;
using System.IO;

namespace Market.Services.EntityServices
{
    public class ImageService : FileService
    {
        private static readonly IEnumerable<string> SupportedMimeTypes = new List<string> { "image/jpeg", "image/png" };

        public override async Task<Result<FileEntity>> Create(IFormFile formFile)
        {
            if (formFile == null)
                return Result.Failure<FileEntity>("FormFile is null");

            bool isSupportedType = false;
            foreach (var mimeType in SupportedMimeTypes)
                if (mimeType == formFile.ContentType)
                {
                    isSupportedType = true;
                    break;
                }

            if (isSupportedType is false)
                return Result.Failure<FileEntity>($"Type {formFile.ContentType} is not a picture");

            var result = await base.Create(formFile);
            return Result.Success(result.Value);
        }

    }
}