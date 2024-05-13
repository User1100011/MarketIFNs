using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(Id))]
    public class ProductEntity
    {
        public ProductEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required, Column("id")]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<TagEntity> Tags { get; set; }
        [Required]
        public List<ImageEntity> Images { get; set; }
        [Required]
        public List<ProductSpecificationEntity> Specifications { get; set; }
        [Required]
        public List<DeliveryServiceEntitycs> DeliveryServices { get; set; }
    }
}
