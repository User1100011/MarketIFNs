namespace Market.Interfaces.HashingInterfaces
{
    public interface IPasswordHasher
    {
        public string Hashing(string password);
    }
}
