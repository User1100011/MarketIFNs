using Market.Models;
using Market.Models.Entityes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Market.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            if (Database.CanConnect() is false)
                Database.EnsureCreated();
        }

        public DbSet<SalesmanEntity> Salesmans => Set<SalesmanEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<ReviewEntity> Reviews => Set<ReviewEntity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>().UseTphMappingStrategy();
            //Подход TPH - Table Per Hierarchy = Таблица на одну иерархию классов


            base.OnModelCreating(builder);
        }
    }
}
