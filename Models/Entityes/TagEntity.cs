using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(TagId))]
    public class TagEntity
    {
        [Required, Column("id")]
        public Guid TagId { get; set; }
        [Required]
        public string Name { get; init; }
        public TagEntity(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Name = name;
        }
    }
}
