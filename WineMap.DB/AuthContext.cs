using Microsoft.AspNet.Identity.EntityFramework;

namespace WineMap.DB
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}