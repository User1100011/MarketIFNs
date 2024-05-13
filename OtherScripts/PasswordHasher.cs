using Market.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Market.OtherScripts
{
    public class PasswordHasher : IPasswordHasher, IHashVerify
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