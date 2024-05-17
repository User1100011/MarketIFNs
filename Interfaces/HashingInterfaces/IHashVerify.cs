namespace Market.Interfaces.HashingInterfaces
{
    public interface IHashVerify
    {
        public bool Verify(string password, string hashPasword);
    }
}
