namespace Market.Interfaces
{
    public interface IHashVerify
    {
        public bool Verify(string password, string hashPasword);
    }
}
