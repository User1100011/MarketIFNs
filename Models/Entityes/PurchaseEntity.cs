using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(Id))]
    public class PurchaseEntity
    {
        public PurchaseEntity()
        {
            Id = Guid.NewGuid();
        }
        [Required, Column("id")]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
