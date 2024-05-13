namespace Market.Interfaces
{
    public interface IPasswordHasher
    {
        public string Hashing(string password);
    }
}
