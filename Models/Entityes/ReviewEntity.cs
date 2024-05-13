using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    public class ReviewEntity
    {
        public ReviewEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required, Column("id")]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required, Range(1, 10)]
        public int Grade { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
