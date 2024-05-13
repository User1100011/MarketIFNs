using Market.DbContexts;
using Market.Models.Entityes;

namespace Market.Services.EntityServices
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(UserEntity user)
        {
            if (user is null)
                return false;

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        public UserEntity? Read(Guid userId)
        {
            return _context.Find<UserEntity>(userId);
        }
        public bool Update(Guid userId, UserEntity newValue)
        {
            var user = _context.Find<UserEntity>(userId);

            if (user is null || newValue is null)
                return false;

            user = newValue;

            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(Guid userId)
        {
            var user = _context.Find<UserEntity>(userId);
            
            if (user is null)
                return false;
            
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
