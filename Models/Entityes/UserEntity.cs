using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Models.Entityes
{
    [PrimaryKey(nameof(Id))]
    public class UserEntity : IdentityUser<Guid>
    {
        public UserEntity()
        {
            Id = Guid.NewGuid();
        }
        [Required, Column("id")]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        [Column("name"), Required]
        public override string? UserName { get => base.UserName; set => base.UserName = value; }

        [Column("email"), Required]
        public override string? Email { get => base.Email; set => base.Email = value; }
        [Column("emailConfirmed"), Required]
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

        [Column("passwordHash"), Required]
        public override string? PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }

        [Column("sum")]
        public int Sum { get; set; }
        [Column("purchases"), Required]
        public List<PurchaseEntity> Purchases { get; set; }

        [Column("profilePicturePath")]
        public string ProfilePicturePath { get; set; }

        [Column("creditCard")]
        public string CreditCard { get; set; }
    }
}
