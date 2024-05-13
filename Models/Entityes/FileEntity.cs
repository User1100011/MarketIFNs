using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(FileId))]
    public class FileEntity
    {
        public FileEntity()
        {
            FileId = Guid.NewGuid();
        }
        [Required, Column("id")]
        public Guid FileId { get; private set; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Path { get; init; }

        private const string fileStorage = @"C:\Timur_Directoryes\Files\Images";

        public static async Task<Result<FileEntity>> FileCreate(IFormFile formFile)
        {
            if (formFile is null)
                return Result.Failure<FileEntity>("FormFile is null");

            try
            {
                var id = Guid.NewGuid();
                var name = formFile.FileName;

                var filePath = System.IO.Path.Combine(fileStorage, id.ToString());

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
