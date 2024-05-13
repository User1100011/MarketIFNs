using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(Id))]
    public class DeliveryServiceEntitycs
    {
        public DeliveryServiceEntitycs()
        {
            Id = Guid.NewGuid();
        }

        [Required, Column("id")]
        public Guid Id { get; set; }

        [Required, Column("name")]
        public string Name { get; set; }

        [Required, Column("description")]
        public string Description { get; set; }
    }
}
