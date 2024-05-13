using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using File = Market.Models.Entityes.FileEntity;

namespace Market.Models.Entityes
{
    public class ImageEntity : FileEntity
    {
        private static readonly IEnumerable<string> SupportedMimeTypes = new List<string> { "image/jpeg", "image/png" };
        public static async Task<Result<ImageEntity>> ImageCreate(IFormFile formFile)
        {
            if (formFile == null)
                return Result.Failure<ImageEntity>("FormFile is null");

            bool isSupportedType = false;
            foreach (var mimeType in SupportedMimeTypes)
                if (mimeType == formFile.ContentType)
                {
                    isSupportedType = true;
                    break;
                }

            if (isSupportedType is false)
                return Result.Failure<ImageEntity>($"Type {formFile.ContentType} is not a picture");

            var result = await FileCreate(formFile);
            return Result.Success((ImageEntity)result.Value);
        }
    }
}
