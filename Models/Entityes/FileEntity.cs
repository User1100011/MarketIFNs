using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid FileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
