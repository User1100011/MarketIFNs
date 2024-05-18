using CSharpFunctionalExtensions;
using Market.Models.Entityes;

namespace Market.Interfaces.FileInterfaces
{
    public interface IFileCreateAsync
    {
        Task<Result<FileEntity>> Create(IFormFile formFile);
    }
}