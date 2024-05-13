using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Market.Models.Entityes
{
    public class ProductSpecificationEntity
    {
        public ProductSpecificationEntity()
        {
            Id = Guid.NewGuid();
        }
        [Required, Column("id")]
        public Guid Id { get; set; }

        [Column("specificationName"), Required]
        public string Name { get; set; }

        [Column("specificationText"), Required]
        public string Text { get; set; }
    }
}
