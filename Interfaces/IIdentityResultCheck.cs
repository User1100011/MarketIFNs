using Microsoft.AspNetCore.Identity;

namespace Market.Interfaces
{
    public interface IIdentityResultCheck
    {
        public bool Check(IdentityResult identityResult);
    }
}
