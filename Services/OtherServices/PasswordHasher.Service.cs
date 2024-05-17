using Market.Interfaces.HashingInterfaces;
using Microsoft.AspNetCore.Identity;

namespace Market.Services.OtherServices
{
    public class PasswordHasherService : IPasswordHasher, IHashVerify
    {
        public string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Verify(string password, string hashPasword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPasword);
        }
    }
}