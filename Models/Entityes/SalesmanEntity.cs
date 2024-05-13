using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(Id))]
    public class SalesmanEntity
    {
        public SalesmanEntity()
        {
            Id = Guid.NewGuid();
        }
        [Required, Column("id")]
        public Guid Id { get; set; }

        [Column("salesmanName"), Required]
        public string Name { get; set; }

        [Column("salesmanName"), Required]
        public string Description { get; set; }



        [Column("ordersNumber")]
        public int OrdersNumber { get; set; }

        [Column("generalProductsRating")]
        public int GeneralProductsRating { get; set; }

        public List<ProductEntity> Products { get; set; }
    }
}
